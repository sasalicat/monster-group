using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_ShieldBlock : skill_representation
{
    public string Explanation
    {
        get
        {
            return "任何傷害都能有幾率格擋5點傷害";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_ShieldBlock";
        }
    }

    public string SkillName
    {
        get
        {
            return "盾牌格擋";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
