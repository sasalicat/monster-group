using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compositeStrip : MonoBehaviour {
    public GameObject mainIcon;//手動拉取
    public GameObject table;//手動拉取
    public GameObject composButtom;//手動拉取
    public Text priceText;
    public GameObject[] partIcons;
    private item_representation repre;
    private int itemNo;
    public delegate void withnothing();
    private withnothing compos_callback;
    public void init(int no, bool active, GameObject panel)
    {
        repre = itemList.main.objects[no];
        itemNo = no;
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
            priceText.text = "" + repre.Price;
        }
        else
        {
            composButtom.SetActive(false);
        }
    }
    public void init(int no, bool active, GameObject panel,withnothing callback)
    {
        init(no, active, panel);
        compos_callback += callback;
    }
    public void composite()
    {
        bool complete = true;
        foreach (int no in repre.Parts) {
            if (!dataWarehouse.main.nowData.itemInBag.Contains(no))
            {
                complete = false;
                break;
            }
        }
        if (complete) {
            foreach(int no in repre.Parts)
            {
                dataWarehouse.main.nowData.itemInBag.Remove(no);
            }
            dataWarehouse.main.nowData.itemInBag.Add(itemNo);
            dataWarehouse.main.updateBagItem(dataWarehouse.main.nowData.itemInBag);
            compos_callback();
        }
    }
}
