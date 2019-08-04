using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_elemAffinity : skill_representation
{
    public string Explanation
    {
        get
        {
            return "法術抗性+25 造成燃燒,麻痺,寒冷持續時間+50%";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_elemAffinity";
        }
    }

    public string SkillName
    {
        get
        {
            return "元素親和";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
