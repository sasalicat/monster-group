using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_wildRoar : skill_representation
{
    public string Explanation
    {
        get
        {
            return "嘲諷一個隨機敵方單位,本單位獲得30點額外護甲5秒";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_wildRoar";
        }
    }

    public string SkillName
    {
        get
        {
            return "野性咆哮";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
