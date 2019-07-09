using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        foreach(int no in traget.skillPool)
        {
            role.skillNos.Add(no);
        }

        role.data.attributeUpdate = traget.Attributes;
        dataWarehouse.main.nowData.moneyLeft -= traget.Price;
    }
    public static void transferTo(RoleRecord role,careerInf traget){
        role.careers.Add(traget.careerNo);
        List<int> skills = new List<int>();//所有技能池內角色尚未擁有的技能
        foreach(int no in traget.skillPool)
        {
            if (!role.skillNos.Contains(no))
            {
                skills.Add(no);
            }
        }
        if (skills.Count > 0)
        {
            int index = Random.Range(0, skills.Count);
            role.skillNos.Add(skills[index]);
        }
        else {
            Debug.LogWarning("在轉職成"+ traget.name+"的過程中並沒有新增任何人技能");
        }
        role.data.attributeUpdate = traget.Attributes;
        dataWarehouse.main.nowData.moneyLeft -= traget.Price;
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
                int index = Random.Range(0, skills.Count);
                role.skillNos.Add(skills[index]);
            }
            else
            {
                Debug.LogWarning("在初始化職業時" + career.name + "的過程中並沒有新增任何人技能");
            }
            role.data.attributeUpdate = career.Attributes;
        }
    }

    public RoleRecord randomRoleFor(int level)
    {//level1為種族 level2為基礎職業
        if (level < 2) {
            Debug.LogWarning("randomRoleFor 的level為:"+level+"小於2");
            return null;
        }
        RoleRecord newRole = new RoleRecord();
        int race= baseRaceNos[Random.Range(0,baseRaceNos.Count)];
        level -= 2;
        giveRace(newRole, objects[race]);
        int idx = baseCareerNos[Random.Range(0, baseRaceNos.Count)];
        careerInf nowCareer = objects[idx];
        for(int nowlv = 0; nowlv < level; nowlv++)
        {
            int nextNo= nowCareer.nexrCareer[Random.Range(0, nowCareer.nexrCareer.Count)];
            nowCareer = objects[nextNo];
            transferTo(newRole, nowCareer);
        }
        return newRole;
    }
}
