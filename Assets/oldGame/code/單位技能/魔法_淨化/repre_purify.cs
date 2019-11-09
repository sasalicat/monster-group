using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_purify : skill_representation
{
    public string Explanation
    {
        get
        {
            return "用火焰,淨化一切!!!";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_purify";
        }
    }

    public string SkillName
    {
        get
        {
            return "淨化";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
