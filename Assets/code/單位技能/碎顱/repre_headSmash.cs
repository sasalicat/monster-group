using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_headSmash : skill_representation
{
    public string Explanation
    {
        get
        {
            return "對自身造成等於15%生命值上限的真實傷害,眩暈目標3秒,冷卻值5s";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_headSmash";
        }
    }

    public string SkillName
    {
        get
        {
            return "碎顱";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
