using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_iceShield : skill_representation
{
    public string Explanation
    {
        get
        {
            return "使用時請穿戴厚棉衣";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_iceShield";
        }
    }

    public string SkillName
    {
        get
        {
            return "寒冰護盾";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
