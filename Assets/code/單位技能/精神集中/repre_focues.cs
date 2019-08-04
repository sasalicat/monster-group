using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_focues : skill_representation
{
    public string Explanation
    {
        get
        {
            return "單位生命值大於等於50%時智力+80";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_focues";
        }
    }

    public string SkillName
    {
        get
        {
            return "精神集中";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
