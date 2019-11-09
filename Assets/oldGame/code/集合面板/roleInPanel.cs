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
    public GameObject phantomObj;

    public void init(RoleRecord inf, GameObject panel)
    {
        roleInf = inf;
        Icon.sprite = ImageList.main.headIcons[inf.race];
        if (itemName != null) {
            string name= careerList.main.objects[inf.careers[inf.careers.Count - 1]].name;
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
            player.army.Add(roleInf);
            player.moneyLeft -= price;
            Icon.color = new Color(0.5f, 0.5f, 0.5f);
            buyButtom.gameObject.SetActive(false);
            onSoldOut(roleInf);
            dataWarehouse.main.onPlayerUpdate();
            dataWarehouse.main.onArmyUpdate();
        }
    }
    void onPhantomDelete(headPhantom phant)
    {
        if (phant.girdsAttach.Count > 0) {
            upgradeBox box =phant.girdsAttach[0].GetComponent<upgradeBox>();
            if (box != null) {
                box.onPick(roleInf);
            }
        }
    }
    public void onDragBeg()
    {
        GameObject obj= Instantiate(phantomObj);
        obj.GetComponent<headPhantom>().init(roleInf);
        obj.GetComponent<headPhantom>().BefDelete += onPhantomDelete;
    }
}
