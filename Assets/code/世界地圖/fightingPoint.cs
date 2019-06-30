using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightingPoint : MonoBehaviour {
    public List<RoleRecord> enermys=new List<RoleRecord>();
    public GameObject teamPanel;
    public GameObject teamCanvas;
    public static List<RoleRecord> nowEnermyList;
    public void Start() {
        Debug.Log("dataWarehouse main:" + dataWarehouse.main);
        RoleRecord default1 = new RoleRecord(1);
        default1.location = new vec2i(1, 1);
        enermys.Add(default1);

        RoleRecord default2 = new RoleRecord(2);
        default2.location = new vec2i(4, 3);
        enermys.Add(default2);
    }
    public void onTrans()
    {
        GameObject wareHouse = dataWarehouse.main.gameObject;
        transmitData_warfield data = wareHouse.AddComponent<transmitData_warfield>();
        //data.enermy.Add()
    }
    public void onClick()
    {
        nowEnermyList = enermys;
        teamPanel.SetActive(true);
        teamCanvas.SetActive(true);
    }
}
