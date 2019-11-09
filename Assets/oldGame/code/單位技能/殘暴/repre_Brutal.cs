using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_Brutal : skill_representation {
    public string Explanation
    {
        get
        {
            return "如果血量小於50%這會想殺人";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_Brutal";
        }
    }

    public string SkillName
    {
        get
        {
            return "殘暴";
        }
    }

    public void init(unitData nowdata)
    {
        
    }


}
