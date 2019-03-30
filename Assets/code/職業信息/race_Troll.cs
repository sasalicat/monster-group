using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class race_Troll : Career {
    public List<int> NextNo
    {
        get
        {
            return null;
        }
    }

    public int No
    {
        get
        {
            return 2;
        }
    }

    public void addProperty(unitData data)
    {
        data.Now_Attack += 2;
        data.Now_Attack_Speed += 25;
        data.Now_Mag_Resistance += 25;
        data.Now_Mag_Reinforce += 35;
    }

    public void addSkill(List<int> skillNos)
    {
        skillNos.Add(3);
    }


}
