using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beast_jackal : RoleRecord {
    public beast_jackal() {
        race = 8;
        data.Remote = false;

        data.Now_Attack += 5;
        data.Now_Attack_Speed += 50;
        skillNos.Add(0);
    }
}
