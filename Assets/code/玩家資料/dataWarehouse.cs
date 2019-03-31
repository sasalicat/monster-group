using System.Collections;
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
    }
    public void Start()
    {
        Debug.Log("dataWarehouse 初始化----------------------------------------");
        Debug.Log("main為:" + main);
        DontDestroyOnLoad(this);
    }
}
