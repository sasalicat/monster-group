using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightingPoint : MonoBehaviour {
    public List<RoleRecord> enermy;
    public GameObject teamPanel;
    public GameObject teamCanvas;
    public void Start() {
        Debug.Log("dataWarehouse main:" + dataWarehouse.main);
    }
    public void onTrans()
    {
        GameObject wareHouse = dataWarehouse.main.gameObject;
        transmitData_warfield data = wareHouse.AddComponent<transmitData_warfield>();
        //data.enermy.Add()
    }
    public void onClick()
    {
        teamPanel.SetActive(true);
        teamCanvas.SetActive(true);
    }
}
