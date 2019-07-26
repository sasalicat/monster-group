using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_FlameWave : skill_representation {
    public string Explanation
    {
        get
        {
            return "發出一道火焰波,對當前目標的整行從前到後造成傷害,每造成一次傷害下一次傷害衰減為當前的70%";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_FlameWave";
        }
    }

    public string SkillName
    {
        get
        {
            return "火焰波";
        }
    }

    public void init(unitData nowdata)
    {
        
    }

}
