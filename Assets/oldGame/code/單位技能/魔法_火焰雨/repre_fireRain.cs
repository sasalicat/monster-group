using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_fireRain : skill_representation
{
    public string Explanation
    {
        get
        {
            return "對目標和以其3*3格為中心的所有敵方單位造成6點火焰傷害";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_fireRain";
        }
    }

    public string SkillName
    {
        get
        {
            return "火焰雨";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
