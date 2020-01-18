using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_doubleHit : skill_resource
{
    public override string Explanation
    {
        get
        {
            return "基本攻擊會額外指定一個目標,但造成的傷害減少25%";
        }
    }

    public override string IconName
    {
        get
        {
            return "Icon/雙重攻擊";
        }
    }

    public override modifier[] mods
    {
        get
        {
            return new modifier[1] {new mod_1_baseAttackTragetting(1f)};
        }
    }

    public override string[] prafebList
    {
        get
        {
            return new string[0];
        }
    }

    public override string ScriptName
    {
        get
        {
            return "newSkill_doubleHit";
        }
    }

    public override string SkillName
    {
        get
        {
            return "雙重攻擊";
        }
    }
}
