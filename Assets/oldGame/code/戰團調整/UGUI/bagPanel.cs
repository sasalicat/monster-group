using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bagPanel : MonoBehaviour {

    public GameObject iconPrefab;
    public GameObject itemPanel;
    public GameObject mainPanel;

    public List<GameObject> heads;
    public unitData none = new unitData();
    public castItem caster;
	// Use this for initialization
	void Start () {
        List<int> noList = dataWarehouse.main.nowData.itemInBag;
        init(noList);
        dataWarehouse.main.updateBagItem = init;
    }
    public void init(List<int> itemNos)
    {
        foreach (GameObject head in heads)
        {
            Destroy(head);
        }
        Debug.Log("iconPrefab:"+ iconPrefab+ "mainPanel:"+mainPanel);
        int count = 0;
        foreach (int no in itemNos)
        {
            //記得做createheadIcon
            GameObject pobj = Instantiate(iconPrefab, mainPanel.transform);
            heads.Add(pobj);
            print("no:" + no);
            pobj.GetComponent<Image>().sprite = ImageList.main.itemIcon[no];
            pobj.GetComponent<showItemInf>().panel = itemPanel;
            Debug.Log("represemtation:" + itemList.main.representation[no]);
            pobj.GetComponent<showItemInf>().initInf(no,itemList.main.representation[no], none,-1, count);
            //pobj.GetComponent<showItemInf>().caster = caster;
            count++;
            //print("showSkillInf:" + IconPrab.GetComponent<showSkillInf>().panel);
        }
    }
}
