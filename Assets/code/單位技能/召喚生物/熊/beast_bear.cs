using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beast_bear : RoleRecord {
    public beast_bear()
    {
        race = 7;
        data.Remote = false;
        data.Now_Attack_Speed -= 50;
        data.Now_Attack += 5;
        data.Now_Max_Life += 100;
        data.Now_Life_Recover += 3;
        skillNos.Add(0);
        skill
    }
}
