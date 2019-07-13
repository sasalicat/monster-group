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
    public void prepareRole(RoleRecord traget)
    {
        role = traget;
        Debug.Log("careers count:" + traget.careers.Count);
        int no = traget.careers[traget.careers.Count - 1];
        roleBox.sprite = ImageList.main.headIcons[traget.race];
        careerInf nowcareer = careerList.main.objects[no];
        foreach (int cno in nowcareer.nexrCareer)
        {
            careerInf nextcareer = careerList.main.objects[cno];
            GameObject obj =  Instantiate(careerObj, upPanel.transform);
            obj.GetComponent<roleForUpgrade>().init(role, nextcareer, onPickCareer);
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
        foreach (GameObject sobj in skillList)
        {
            Destroy(sobj);
        }
        foreach (int sno in traget.skillPool)
        {
            GameObject sobj = Instantiate(skillObj, skillsPanel.transform);
            sobj.GetComponent<showSkillInf>().initInf(SkillList.main.representation[sno], role.data);
            sobj.GetComponent<showSkillInf>().panel = skillInfPanel;
            skillList.Add(sobj);
        }

    }
}
