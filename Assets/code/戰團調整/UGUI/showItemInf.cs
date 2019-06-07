using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showItemInf : MonoBehaviour {
    private item_representation itemInf;
    public GameObject panel;
   // public
    public void initInf(string name, unitData data)
    {
        itemInf = (item_representation)System.Activator.CreateInstance(System.Type.GetType(name));
        itemInf.init(data);
    }
    public void onMouseDown()
    {
        panel.transform.position = transform.position;
        panel.SetActive(true);
        itemPanel itemPanel = panel.GetComponent<itemPanel>();
        itemPanel.ItemName = itemInf.itemName;
        itemPanel.ItemPrice = itemInf.Price;
        itemPanel.ItemAttri = itemInf.Attributes;
        itemPanel.ItemStatement = itemInf.Explanation;

    }
    public void onMouseUp()
    {
        panel.SetActive(false);
    }
}
