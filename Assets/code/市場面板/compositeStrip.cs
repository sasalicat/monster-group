using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compositeStrip : MonoBehaviour {
    public GameObject mainIcon;//手動拉取
    public GameObject table;//手動拉取
    public GameObject[] partIcons;
    public void init(int no, bool active, GameObject panel)
    {
        item_representation repre = itemList.main.objects[no];
        mainIcon.GetComponent<itemInMarket>().init(no,repre, panel);
        if (repre.Parts != null)
        {
            partIcons = new GameObject[repre.Parts.Count];
            foreach (int idx in repre.Parts)
            {
                GameObject obj = Instantiate(mainIcon, table.transform);
                obj.GetComponent<itemInMarket>().init(idx, itemList.main.objects[idx],panel);
            }
        }
        if (active)
        {
            GetComponent<Image>().color = Color.green;
        }
    }
}
