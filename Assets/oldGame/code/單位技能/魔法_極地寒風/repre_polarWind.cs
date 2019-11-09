using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_polarWind : skill_representation
{
    public string Explanation
    {
        get
        {
            return "對目標和左右兩邊的單位造成6點傷害和3秒的一層寒冷";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_polarWind";
        }
    }

    public string SkillName
    {
        get
        {
            return "極地寒風";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
