using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_simpleHealing : skill_representation
{
    public string Explanation
    {
        get
        {
            return "和名字一樣,就是簡單的治療";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_simpleHealing";
        }
    }

    public string SkillName
    {
        get
        {
            return "簡易治療";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
