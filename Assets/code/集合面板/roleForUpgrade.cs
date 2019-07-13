using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roleForUpgrade : MonoBehaviour {
    private RoleRecord roleInf;
    private bool soldOut = false;
    public Image Icon;//手動拉取
    public Text itemName;//手動拉取
    public Text itemCost;//手動拉取
    public Button buyButtom;//手動拉取
    public rolePanel panel;//初始化時賦予
    public delegate void withRole(RoleRecord arg);
    public withRole onSoldOut;
    public void init(RoleRecord infl)
    {
        roleInf = inf;
        Icon.sprite = ImageList.main.headIcons[inf.race];
        if (itemName != null)
        {
            string name = careerList.main.objects[inf.careers[inf.careers.Count - 1]].name;
            itemName.text = name;

        }
        if (itemCost != null)
        {
            int price = 0;
            foreach (int careerno in roleInf.careers)
            {
                price += careerList.main.objects[careerno].Price;
            }
            itemCost.text = "" + price;
        }
    }
}
