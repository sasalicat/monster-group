using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class careerList : MonoBehaviour {
    public static careerList main = null;
    void OnEnable()
    {
        if (main != null)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }
    void Start()
    {
        objects = new List<careerInf>();
        for (int i = 0; i < careerNames.Count; i++)
        {
            string name = careerNames[i];
            if (name != "" || name != null)
            {
                if (Type.GetType(name) == null)
                {//若無此類
                    Debug.Log("careerInf:" + name + "不存在");
                    objects.Add(null);
                }
                else
                {
                    Debug.Log("Activator.CreateInstance:" + name);
                    objects.Add((careerInf)System.Activator.CreateInstance(System.Type.GetType(name)));
                }
            }
            else
            {
                objects.Add(null);
            }
        }
    }
    public List<string> careerNames;
    public List<careerInf> objects;
    public List<int> baseRaceNos;//記錄類別的信息編號
    public List<int> baseCareerNos;//記錄基礎職業的信息編號
    public static void giveRace(RoleRecord role, careerInf traget)
    {
        role.race = traget.careerNo;
        if (role.skillNos.Count != 0)
        {
            Debug.LogWarning("添加種族"+traget.name+"的時候技能欄不為空");
        }
        foreach(int no in traget.giftSkills)
        {
            role.skillNos.Add(no);
        }

        role.data.attributeUpdate = traget.Attributes;
    }
    public static void transferTo(RoleRecord role,careerInf traget){
        role.careers.Add(traget.careerNo);
        List<int> skills = new List<int>();//所有技能池內角色尚未擁有的技能
        foreach (int no in traget.giftSkills)//添加所有必定獲得的技能
        {
            string name = SkillList.main.representation[no];
            if (Type.GetType("subst_skill_representation").IsAssignableFrom(Type.GetType(name)))
            //if (Type.GetType(name).IsSubclassOf(Type.GetType("subst_skill_representation")))
            {//如果技能敘述繼承了subst_skill_representation
                //則改為從subst_skill_representation的替補中選擇一個技能名稱
                object repre = System.Activator.CreateInstance(System.Type.GetType(name));
                role.skillNos.Add(((subst_skill_representation)repre).substitutNo());

            }
            else
            {
                role.skillNos.Add(no);
            }
        }

        foreach (int no in traget.skillPool)
        {
            if (!role.skillNos.Contains(no))
            {
                skills.Add(no);
            }
        }
        if (skills.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, skills.Count);
            string name = SkillList.main.representation[skills[index]];
            //Debug.Log("skill representation name:" + name + " issubclass:" + Type.GetType(name).IsSubclassOf(Type.GetType("subst_skill_representation")));
            if (Type.GetType("subst_skill_representation").IsAssignableFrom(Type.GetType(name)))
            //if (Type.GetType(name).IsSubclassOf(Type.GetType("subst_skill_representation")))
            {//如果技能敘述繼承了subst_skill_representation
                //則改為從subst_skill_representation的替補中選擇一個技能名稱
                object repre = System.Activator.CreateInstance(System.Type.GetType(name));
                role.skillNos.Add(((subst_skill_representation)repre).substitutNo());

            }
            else
            {
                role.skillNos.Add(skills[index]);
            }
            //role.skillNos.Add(skills[index]);
        }
        else {
            Debug.LogWarning("在轉職成"+ traget.name+"的過程中並沒有新增任何人技能");
        }
        role.data.attributeUpdate = traget.Attributes;
    }
    public void initRoleForCareer(RoleRecord role)
    {
        careerInf race = objects[role.race];
        if (role.skillNos.Count != 0)
        {
            Debug.LogWarning("在初始化角色種族" + race.name + "的時候技能欄不為空");
        }
        foreach (int no in race.skillPool)
        {
            role.skillNos.Add(no);
        }

        role.data.attributeUpdate = race.Attributes;

        foreach (int cno in role.careers)
        {
            careerInf career = objects[cno];
            List<int> skills = new List<int>();//所有技能池內角色尚未擁有的技能
            foreach (int no in career.skillPool)
            {
                if (!role.skillNos.Contains(no))
                {
                    skills.Add(no);
                }
            }
            if (skills.Count > 0)
            {
                int index = UnityEngine.Random.Range(0, skills.Count);
                string name = SkillList.main.representation[skills[index]];
                if(Type.GetType("subst_skill_representation").IsAssignableFrom(Type.GetType(name)))
                //if (Type.GetType(name).IsSubclassOf(Type.GetType("subst_skill_representation")))
                {//如果技能敘述繼承了subst_skill_representation
                    //則改為從subst_skill_representation的替補中選擇一個技能名稱
                    object repre = System.Activator.CreateInstance(System.Type.GetType(name));
                    role.skillNos.Add(((subst_skill_representation)repre).substitutNo());

                }
                else
                {
                    role.skillNos.Add(skills[index]);
                }
            }
            else
            {
                Debug.LogWarning("在初始化職業時" + career.name + "的過程中並沒有新增任何人技能");
            }
            role.data.attributeUpdate = career.Attributes;
        }
    }
    public static int totalPriceOf(careerInf career)
    {
        int price = 0;
        while (true)
        {
            price += career.Price;
            if (career.frontCareer <0)
            {
                break;
            }
            else
            {
                career = main.objects[career.frontCareer];
            }
        }
        return price;
    }
    public RoleRecord randomRoleFor(int level,bool teammate)
    {
        RoleRecord newRole = randomRoleFor(level);
        newRole.teammate = teammate;
        return newRole;
    }
    public RoleRecord randomRoleFor(int level)
    {//level1為種族 level2為基礎職業
        if (level < 2) {
            Debug.LogWarning("randomRoleFor 的level為:"+level+"小於2");
            return null;
        }
        RoleRecord newRole = new RoleRecord();
        int race= baseRaceNos[UnityEngine.Random.Range(0,baseRaceNos.Count)];
        level -= 2;
        giveRace(newRole, objects[race]);
        int index = UnityEngine.Random.Range(0, baseCareerNos.Count);
        int no = baseCareerNos[index];
        careerInf nowCareer = objects[no];
        transferTo(newRole, nowCareer);
        for(int nowlv = 0; nowlv < level; nowlv++)
        {
            int nextNo= nowCareer.nexrCareer[UnityEngine.Random.Range(0, nowCareer.nexrCareer.Count)];
            nowCareer = objects[nextNo];
            transferTo(newRole, nowCareer);
        }
        return newRole;
    }
}
