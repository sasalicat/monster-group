using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beast_spider : RoleRecord {
    public beast_spider() {
        race = 8;
        data.Remote = false;

        data.Now_Attack += 2;
        data.Now_Attack_Speed += 30;
        data.Now_Life_Recover += 2;
        data.Now_Mag_Resistance += 30;
        skillNos.Add(0);
        skillNos.Add(39);
    }
}
