using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class equipBar : MonoBehaviour {
    public RoleRecord role;
    public GameObject IconPrab;
    public GameObject itemPanel;
    List<GameObject> heads = new List<GameObject>();
    public void init(RoleRecord data)
    {
        foreach (GameObject head in heads)
        {
            Destroy(head);
        }
        role = data;
        foreach (int no in role.itemNos)
        {
            //記得做createheadIcon
            GameObject pobj = Instantiate(IconPrab, transform);
            heads.Add(pobj);
            print("no:" + no);
            pobj.GetComponent<Image>().sprite = ImageList.main.itemIcon[no];
            print("技能" + IconPrab.name + "添加skillPanel" + itemPanel);
            pobj.GetComponent<showItemInf>().panel = itemPanel;
            pobj.GetComponent<showItemInf>().initInf(itemList.main.representation[no], role.data);
            //print("showSkillInf:" + IconPrab.GetComponent<showSkillInf>().panel);
        }
    }
}
