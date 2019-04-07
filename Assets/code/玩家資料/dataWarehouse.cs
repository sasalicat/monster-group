﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataWarehouse : MonoBehaviour {
    public PlayerInf nowData;
    public static dataWarehouse main;
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
        nowData.army.Add(new RoleRecord(2));
        nowData.army.Add(new RoleRecord(0));
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
