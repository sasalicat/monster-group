using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marketPanel : MonoBehaviour {
    public GameObject itemObj;//手動拉取
    public GameObject itemPanel;//手動拉取
    public GameObject soldPanel;//手動拉取
    public GameObject composPanel;//手動拉取
    public GameObject soldButtom;//手動拉取
    public GameObject composButtom;//手動拉取
    List<GameObject> itemObjs ;
	public void init(List<int> itemNos)
    {
        Debug.Log("market panel init:");
        itemObjs = new List<GameObject>();
        foreach(int no in itemNos)
        {
            Debug.Log("item No:" + no);
            GameObject obj= (GameObject)Instantiate(itemObj,  soldPanel.transform);
            obj.GetComponent<itemInMarket>().init(no, itemList.main.objects[no], itemPanel);
            itemObjs.Add(obj);
        }
        
    }
    public void quit()
    {
        gameObject.SetActive(false);
    }
    public void compositeButtomClick()
    {
        soldPanel.SetActive(false);
        composPanel.SetActive(true);
        composPanel.GetComponent<compositePanel>().init();
        soldButtom.SetActive(true);
        composButtom.SetActive(false);
    }
    public void marketButtomClick()
    {
        composPanel.GetComponent<compositePanel>().cancer();
        composPanel.SetActive(false);
        soldPanel.SetActive(true);
        composButtom.SetActive(true);
        soldButtom.SetActive(false);
    }
}
