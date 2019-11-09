using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillBar : MonoBehaviour
{
    public RoleRecord role;
    public GameObject IconPrab;
    public GameObject skillPanel;
    List<GameObject> heads = new List<GameObject>();
    public void init(RoleRecord data)
    {
        foreach(GameObject head in heads)
        {
            Destroy(head);
        }
        role = data;
        foreach (int no in role.skillNos)
        {
            //記得做createheadIcon
            GameObject pobj = Instantiate(IconPrab, transform);
            heads.Add(pobj);
            print("no:" + no);
            pobj.GetComponent<Image>().sprite = ImageList.main.skillIcons[no];
            print("技能" + IconPrab.name + "添加skillPanel" + skillPanel);
            pobj.GetComponent<showSkillInf>().panel = skillPanel;
            pobj.GetComponent<showSkillInf>().initInf(SkillList.main.representation[no],role.data);
            print("showSkillInf:" + IconPrab.GetComponent<showSkillInf>().panel);
        }
    }
}
