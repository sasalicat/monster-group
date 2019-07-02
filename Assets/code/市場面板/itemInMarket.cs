using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class itemInMarket : MonoBehaviour {
    private item_representation itemInf;
    public Image Icon;//手動拉取
    public Text itemName;//手動拉取
    public Text itemCost;//手動拉取
    public itemPanel panel;//初始化時賦予
    public void init(item_representation inf,GameObject panel)
    {
        itemName.text = inf.itemName;
        itemCost.text = ""+inf.Price;
        itemInf = inf;
        this.panel = panel.GetComponent<itemPanel>();
    }
    public void onClick() {
        panel.gameObject.SetActive(true);
        panel.ItemName = itemInf.itemName;
        panel.ItemPrice = itemInf.Price;
        panel.ItemCommentary = itemInf.Commentary;
        panel.ItemExplanation = itemInf.Explanation;
    }
}
