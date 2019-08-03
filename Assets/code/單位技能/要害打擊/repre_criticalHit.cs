using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_criticalHit : skill_representation
{
    public string Explanation
    {
        get
        {
            return "造成物理傷害時有20%幾率造成20點額外真實傷害";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_criticalHit";
        }
    }

    public string SkillName
    {
        get
        {
            return "擊中要害";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
