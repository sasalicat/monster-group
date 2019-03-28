using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class race_Orc : Career
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
            return 0;
        }
    }

    public void addProperty(unitData data)
    {
        data.Now_Attack += 5;
        data.Now_Max_Life += 50;
    }

    public void addSkill(List<int> skillNos)
    {
        skillNos.Add(2);
    }
}
