using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_fastfrost : skill_representation
{
    public string Explanation
    {
        get
        {
            return "擊暈目標1.5秒,若目標有寒冷狀態則擊暈目標3秒";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_fastfrost";
        }
    }

    public string SkillName
    {
        get
        {
            return "快速凍結";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
