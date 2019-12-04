using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_normalAttack : skill_resource
{
    public override string Explanation
    {
        get
        {
            return "基礎攻擊,造成等於力量的傷害";
        }
    }

    public override string[] prafebList
    {
        get
        {
            return new string[1] { "effection/新被擊_濺血" }; 
        }
    }

    public override string ScriptName
    {
        get
        {
            return "newSkill_normalAttack";
        }
    }

    public override string SkillName
    {
        get
        {
            return "物理攻擊";
        }
    }
}
