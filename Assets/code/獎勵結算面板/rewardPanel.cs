﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rewardPanel : MonoBehaviour {
    public GameObject roleInfPanel;//手動拉取
    public GameObject itemInfPanel;//手動拉取
    public GameObject roleHead;//手動拉取
    public GameObject itemHead;//手動拉取
    public GameObject mainPanel;//手動拉取
    public Text goldNum;//手動拉取
    public transScene trans;//手動拉取
    private reward currentReward;
    public void extractReward()
    {
        dataWarehouse.main.nowData.moneyLeft += currentReward.bonus;
        foreach(RoleRecord role in currentReward.roles)
        {
            dataWarehouse.main.nowData.army.Add(role);
        }
        foreach (int no in currentReward.itemNos) {
            dataWarehouse.main.nowData.itemInBag.Add(no);
        }
    }
    // Use this for initialization
    public void init(reward reward) {
        currentReward = reward;
        foreach(RoleRecord role in reward.roles)
        {
            GameObject head = Instantiate(roleHead, mainPanel.transform);
            head.GetComponent<roleInPanel>().init(role, roleInfPanel);
        }
        foreach(int no in reward.itemNos)
        {
            GameObject item = Instantiate(itemHead, mainPanel.transform);
            item.GetComponent<itemInMarket>().init(no, itemList.main.objects[no], itemInfPanel);
        }
        goldNum.text = ""+reward.bonus;
        trans.beforeTrans += extractReward;
    }
}
