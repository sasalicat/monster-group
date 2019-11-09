using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_dropWeapon : skill_representation
{
    public string Explanation
    {
        get
        {
            return "繳械目標2.5秒";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_dropWeapon";
        }
    }

    public string SkillName
    {
        get
        {
            return "繳械";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
