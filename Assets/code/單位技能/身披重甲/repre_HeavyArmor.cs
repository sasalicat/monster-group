using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_HeavyArmor : skill_representation
{
    public string Explanation
    {
        get
        {
            return "這可是板甲哦";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_HeavyArmor";
        }
    }

    public string SkillName
    {
        get
        {
            return "身披重甲";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
