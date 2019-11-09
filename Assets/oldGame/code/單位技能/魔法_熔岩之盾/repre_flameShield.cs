using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_flameShield : skill_representation {
    public string Explanation
    {
        get
        {
            return "創建一個吸收20點傷害的熔岩之盾,會受創建者智力影響哦~~";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_flameShield";
        }
    }

    public string SkillName
    {
        get
        {
            return "熔岩之盾";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
