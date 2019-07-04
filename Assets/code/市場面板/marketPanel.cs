using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marketPanel : MonoBehaviour {
    public GameObject itemObj;//手動拉取
    public GameObject itemPanel;//手動拉取
    public GameObject mainPanel;//手動拉取
    List<GameObject> itemObjs ;
	public void init(List<int> itemNos)
    {
        Debug.Log("market panel init:");
        itemObjs = new List<GameObject>();
        foreach(int no in itemNos)
        {
            Debug.Log("item No:" + no);
            GameObject obj= (GameObject)Instantiate(itemObj,  mainPanel.transform);
            obj.GetComponent<itemInMarket>().init(no, itemList.main.objects[no], itemPanel);
            itemObjs.Add(obj);
        }
    }
}
