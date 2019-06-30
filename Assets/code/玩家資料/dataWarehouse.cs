﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataWarehouse : MonoBehaviour {
    public PlayerInf nowData;
    public static dataWarehouse main;
    public delegate void withIntList(List<int> list);
    public delegate void withBIdict(Dictionary<byte, int> dict);
    public withIntList updateBagItem;//主要用於itemInBag更新時觸發對應UI的更新(bagPanel)
    public withIntList updateNowRoleItems;//主要用於army[index].itemNos更新時觸發對應UI的更新(equipBar)
    public withBIdict updateNowRoleAttr;
    public withBIdict denyNowRoleAttr;

    void OnEnable()
    {
        if (main != null)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }
    public void createNewArchive()
    {
        Debug.Log("創建新檔案");
        nowData = new PlayerInf();
        nowData.army.Add(new RoleRecord(1));
        nowData.army[0].index = 0;
        nowData.army[0].skillNos.Add(1);
        nowData.army[0].skillNos.Add(5);
        nowData.army[0].itemNos.Add(1);
        nowData.army[0].itemNos.Add(2);
        nowData.army.Add(new RoleRecord(2));
        nowData.army[1].index = 1;
        nowData.army[1].skillNos.Add(1);
        nowData.army[1].skillNos.Add(8);
        nowData.army[1].skillNos.Add(10);
        nowData.army.Add(new RoleRecord(0));
        nowData.army[2].index = 2;
        nowData.army[2].skillNos.Add(3);
        nowData.army[2].skillNos.Add(5);
        //加一點測試用的裝備
        nowData.itemInBag.Add(1);
        nowData.itemInBag.Add(2);
        nowData.itemInBag.Add(3);
    }
    public void loadArchive() {
        Debug.Log("加載檔案");
        nowData = PlayerInf.loadInf();
        nowData.printInf();
    }
    public void Start()
    {
        Debug.Log("dataWarehouse 初始化----------------------------------------");
        Debug.Log("main為:" + main);
        DontDestroyOnLoad(this);
    }
    private void forDebug()
    {
        //nowData.
    }
}
