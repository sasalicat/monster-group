using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillBar : MonoBehaviour
{
    public RoleRecord role;
    public GameObject IconPrab;
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
            heads.Add(Instantiate(IconPrab,transform));
            print("no:" + no);
            IconPrab.GetComponent<Image>().sprite = ImageList.main.skillIcons[no];
        }
    }
}
