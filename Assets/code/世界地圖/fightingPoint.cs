using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightingPoint : MonoBehaviour {
    public List<RoleRecord> enermy;
    public void Start() {
        Debug.Log("dataWarehouse main:" + dataWarehouse.main);
    }
    public void onClick()
    {
        GameObject wareHouse = dataWarehouse.main.gameObject;
        transmitData_warfield data = wareHouse.AddComponent<transmitData_warfield>();
        //data.enermy.Add()
    }
}
