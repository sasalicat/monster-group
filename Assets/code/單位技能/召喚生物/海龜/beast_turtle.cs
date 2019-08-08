using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beast_turtle : RoleRecord {
    public beast_turtle()
    {
        race = 7;
        data.Remote = false;

        data.Now_Attack += 3;
        data.Now_Max_Life += 50;
        data.Now_Armor += 80;
        skillNos.Add(0);
        skillNos.Add(38);
    }

}
