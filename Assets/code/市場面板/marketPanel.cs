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
    List<GameObject> itemObjs;
    List<int> nos;
    public delegate void withList(List<int> arg);
    private withList callback;
    public void removeNo(int no)
    {
        nos.Remove(no);
    }
	public void init(List<int> itemNos,withList update_cb)
    {
        Debug.Log("market panel init:");
        itemObjs = new List<GameObject>();
        foreach(int no in itemNos)
        {
            Debug.Log("item No:" + no);
            GameObject obj= (GameObject)Instantiate(itemObj,  soldPanel.transform);
            obj.GetComponent<itemInMarket>().init(no, itemList.main.objects[no], itemPanel);
            obj.GetComponent<itemInMarket>().onSoldOut += removeNo;
            itemObjs.Add(obj);
            
        }
        nos = itemNos;
        callback += update_cb;
    }
    public void quit()
    {
        foreach(GameObject obj in itemObjs)
        {
            Destroy(obj);
        }
        gameObject.SetActive(false);
        callback(nos);
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
