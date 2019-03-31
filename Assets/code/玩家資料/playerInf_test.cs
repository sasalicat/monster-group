using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInf_test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerInf pinf = new PlayerInf();
        pinf.lv = 10;
        pinf.moneyLeft = 66;
        pinf.itemInBag = new List<int>() { 0, 2, 3, 4, 19 };
        unitData unit1 = new unitData();
        unit1.Now_Attack = 20;
        unit1.Now_Attack_Speed = 90;
        unit1.Now_Max_Life = 199;
        RoleRecord role1 = new RoleRecord(2);
        role1.data = unit1;
        Debug.Log("role1.data: NowAtk:" + unit1.Now_Attack);
        unitData_Profile ud_pf = unit1.getProflie();
        Debug.Log("unitData: baseAttack:" + ud_pf.base_attack + " atkSpeed:" + ud_pf.attack_speed_reinforce + " maxLife:" + ud_pf.max_life_point);
        role1.itemNos=new List<int>(){1,1,2,3};


        unitData unit2 = new unitData();
        unit2.Now_Mag_Reinforce = 50;
        unit2.Now_Mag_Resistance = 97;
        unit2.Now_Armor = 35;
        RoleRecord role2 = new RoleRecord(0);
        role2.data = unit2;
        role2.skillNos = new List<int>() { 1, 2, 26, 10 };
        role2.location = new vec2i(1, 1);

        pinf.army.Add(role1);
        pinf.army.Add(role2);
        pinf.saveInf();

        PlayerInf newInf = PlayerInf.loadInf();
        newInf.printInf();
	}
	
}
