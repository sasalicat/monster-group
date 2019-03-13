using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_WildForce : skill_representation {
    public string Explanation
    {
        get
        {
            return "獸人永不為奴!除非包吃包住";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_WildForce";
        }
    }

    public string SkillName
    {
        get
        {
            return "野性之力";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
