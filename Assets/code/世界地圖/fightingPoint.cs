using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightingPoint : MonoBehaviour {
    public List<RoleRecord> enermys=new List<RoleRecord>();
    public GameObject teamPanel;
    public GameObject teamCanvas;
    public GameObject playerCanvas;
    public static List<RoleRecord> nowEnermyList;
    public void Start() {
        Debug.Log("dataWarehouse main:" + dataWarehouse.main);
        RoleRecord default1 = careerList.main.randomRoleFor(3, false);
        default1.location = new vec2i(1, 1);
        enermys.Add(default1);

        RoleRecord default2 = careerList.main.randomRoleFor(3, false);
        default2.location = new vec2i(4, 3);
        enermys.Add(default2);

        RoleRecord reward_role1 = careerList.main.randomRoleFor(3, true);
        RoleRecord reward_role2 = careerList.main.randomRoleFor(2, true);
        dataWarehouse.main.levelReward.roles = new List<RoleRecord>() { reward_role1, reward_role2 };
        dataWarehouse.main.levelReward.itemNos = new List<int>() { 0, 1, 2 };
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
        playerCanvas.SetActive(false);
    }
}
