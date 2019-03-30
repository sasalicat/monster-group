using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class race_DarkElf : Career
{
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
            return 1;
        }
    }

    public void addProperty(unitData data)
    {
        data.Now_Attack_Speed += 50;
        data.Now_Cooldown_Reinforce += 50;
    }

    public void addSkill(List<int> skillNos)
    {
        skillNos.Add(3);
    }
}
