using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_SecretlyShut : skill_representation {
    public string Explanation
    {
        get
        {
            return "我就偷偷地射一槍,你氣不氣?";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_SecretlyShut";
        }
    }

    public string SkillName
    {
        get
        {
            return "冷槍";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
