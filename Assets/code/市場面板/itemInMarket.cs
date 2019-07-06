using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class itemInMarket : MonoBehaviour {
    private item_representation itemInf;
    private int no;
    private bool soldOut = false;
    public Image Icon;//手動拉取
    public Text itemName;//手動拉取
    public Text itemCost;//手動拉取
    public Button buyButtom;//手動拉取
    public itemPanel panel;//初始化時賦予

    public void init(int itemNo,item_representation inf,GameObject panel)
    {
        no = itemNo;
        Icon.sprite = ImageList.main.itemIcon[no];
        itemName.text = inf.itemName;
        itemCost.text = ""+inf.Price;
        itemInf = inf;
        this.panel = panel.GetComponent<itemPanel>();
    }
    public void onClicking() {
        panel.gameObject.SetActive(true);
        panel.transform.position = transform.position;
        panel.ItemName = itemInf.itemName;
        panel.ItemPrice = itemInf.Price;
        panel.ItemCommentary = itemInf.Commentary;
        panel.ItemExplanation = itemInf.Explanation;
    }
    public void onUnClick() {
        panel.gameObject.SetActive(false);
    }
    public void buy()
    {
        PlayerInf player = dataWarehouse.main.nowData;
        if (player.moneyLeft >= itemInf.Price&&!soldOut)
        {
            player.itemInBag.Add(no);
            player.moneyLeft -= itemInf.Price;
            Icon.color = new Color(0.5f, 0.5f, 0.5f);
            buyButtom.gameObject.SetActive(false);
            dataWarehouse.main.updateBagItem(player.itemInBag);
            dataWarehouse.main.onPlayerUpdate();
        }
    }
}
