using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class upgradePanel : MonoBehaviour {
    public GameObject careerObj;
    public GameObject upPanel; 
    public GameObject skillObj;//手動拉取,技能頭像
    public GameObject skillInfPanel;//手動拉取
    public Image roleBox;//手動拉取
    public GameObject skillsPanel;//手動拉取
    public Text atribute;//手動拉取
    RoleRecord role;
    private List<GameObject> objList = new List<GameObject>();
    private List<GameObject> skillList = new List<GameObject>();
	// Use this for initialization
    public void aftUpgrade()
    {
        cancer();
        prepareRole(role);
    }
    public void prepareRole(RoleRecord traget)
    {
        role = traget;
        cancer();
        Debug.Log("careers count:" + traget.careers.Count);
        int no = traget.careers[traget.careers.Count - 1];
        roleBox.sprite = ImageList.main.headIcons[traget.race];
        careerInf nowcareer = careerList.main.objects[no];
        foreach (int cno in nowcareer.nexrCareer)
        {
            careerInf nextcareer = careerList.main.objects[cno];
            GameObject obj =  Instantiate(careerObj, upPanel.transform);
            obj.GetComponent<roleForUpgrade>().init(role, nextcareer, onPickCareer,aftUpgrade);
            objList.Add(obj);
        }

    }
    public void cancer() {
        foreach (GameObject obj in objList)
        {
            Destroy(obj);
        }
        foreach (GameObject sobj in skillList)
        {
            Destroy(sobj);
        }
        objList = new List<GameObject>();
    }
    public void onPickCareer(careerInf traget) {
        string statement = "";
        Dictionary<byte, int> attr = traget.Attributes;
        foreach(KeyValuePair<byte,int> pair in attr)
        {
            statement += " +";
            statement += unitData.getAttributeString(pair.Key);
            statement += ":";
            statement += pair.Value;
        }
        atribute.text = statement;
        foreach (GameObject sobj in skillList)
        {
            Destroy(sobj);
        }
        foreach (int sno in traget.skillPool)
        {
            GameObject sobj = Instantiate(skillObj, skillsPanel.transform);
            sobj.tag = "Untagged";//要設置tag的原因是在compositePanel的技能面板裏有技能的時候,若角色信息面板是打開狀態,則無論怎麼點擊何處RayCast2D都會cast到技能面板的第四個技能
            sobj.GetComponent<showSkillInf>().initInf(SkillList.main.representation[sno], role.data);
            sobj.GetComponent<showSkillInf>().panel = skillInfPanel;
            sobj.GetComponent<Image>().sprite = ImageList.main.skillIcons[sno];
            skillList.Add(sobj);
        }

    }
}
