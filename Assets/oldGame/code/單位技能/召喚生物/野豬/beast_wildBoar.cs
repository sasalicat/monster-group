using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beast_wildBoar : RoleRecord {
    public beast_wildBoar()
    {
        race = 5;
        data = new unitData();
        data.Remote = false;
        data.Now_Attack += 5;
        data.Now_Armor += 20;
        data.Now_Max_Life += 30;

        skillNos.Add(0);
        skillNos.Add(35);
    }
}
