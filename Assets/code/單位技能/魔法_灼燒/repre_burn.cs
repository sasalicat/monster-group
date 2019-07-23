using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_burn : skill_representation
{
    public string Explanation
    {
        get
        {
            return "在這樣的好天氣里,像你這樣的孩子應該...";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_burn";
        }
    }

    public string SkillName
    {
        get
        {
            return "灼燒";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
