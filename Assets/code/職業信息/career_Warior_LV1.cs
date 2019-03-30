using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class career_Warior_LV1 : Career
{
    public List<int> NextNo
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public int No
    {
        get
        {
            return 3;
        }
    }

    public void addProperty(unitData data)
    {
        data.Now_Attack += 2;
        data.Now_Armor += 10;
        data.Now_Max_Life += 20;
    }

    public void addSkill(List<int> skillNos)
    {
        skillNos.Add(0);
        skillNos.Add(7);
    }
}
