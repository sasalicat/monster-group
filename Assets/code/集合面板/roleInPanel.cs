using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class roleInPanel : MonoBehaviour
{
    private RoleRecord roleInf;
    private bool soldOut = false;
    public Image Icon;//手動拉取
    public Text itemName;//手動拉取
    public Text itemCost;//手動拉取
    public Button buyButtom;//手動拉取
    public rolePanel panel;//初始化時賦予
    public delegate void withRole(RoleRecord arg);
    public withRole onSoldOut;

    public void init(RoleRecord inf, GameObject panel)
    {
        Icon.sprite = ImageList.main.itemIcon[inf.race];
        if (itemName != null) {
            string name= careerList.main.objects[inf.careers.Count - 1].name;
            itemName.text = name;

        }
        if (itemCost != null) {
            int price = 0;
            foreach (int careerno in roleInf.careers)
            {
                price += careerList.main.objects[careerno].Price;
            }
            itemCost.text = "" + price;
        }
        roleInf = inf;
        this.panel = panel.GetComponent<rolePanel>();
    }
    public void onClicking()
    {
        panel.gameObject.SetActive(true);
        panel.init(roleInf);
    }
    public void onUnClick()
    {
        panel.gameObject.SetActive(false);
    }
    public void buy()
    {
        PlayerInf player = dataWarehouse.main.nowData;
        int price = 0;
        foreach(int careerno in roleInf.careers)
        {
            price += careerList.main.objects[careerno].Price;
        }
        if (player.moneyLeft >= price && !soldOut)
        {
            onSoldOut(roleInf);
        }
    }
}
