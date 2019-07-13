using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roleForUpgrade : MonoBehaviour {
    private RoleRecord roleInf;
    private careerInf career;
    private bool soldOut = false;

    public delegate void withCareer(careerInf career);

    public withCareer onClick_callback;
    public Image Icon;//手動拉取
    public Text itemName;//手動拉取
    public Text itemCost;//手動拉取
    public Button buyButtom;//手動拉取
    public rolePanel panel;//初始化時賦予
    public void init(RoleRecord inf,careerInf career,withCareer callback)
    {
        roleInf = inf;
        this.career =career;
        Debug.Log("Icon" + Icon+"race:"+inf.race);
        Icon.sprite = ImageList.main.headIcons[inf.race];
        if (itemName != null)
        {
            string name = career.name;
            itemName.text = name;

        }
        if (itemCost != null)
        {
            itemCost.text = "" +career.Price;
        }
        onClick_callback = callback;
    }
    public void onClick()
    {
        onClick_callback(career);
    }
    public void upgrade()
    {
        careerList.transferTo(roleInf,career);
    }
}
