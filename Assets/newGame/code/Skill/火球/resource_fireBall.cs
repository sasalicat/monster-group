using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_fireBall : skill_resource
{
    public override string Explanation
    {
        get
        {
            return "造成10點火焰傷害";
        }
    }

    public override string IconName
    {
        get
        {
            return "Icon/火球";
        }
    }

    public override string[] prafebList
    {
        get
        {
            return new string[2] { "effection/火球", "effection/爆炸特效1" };
        }
    }

    public override string ScriptName
    {
        get
        {
            return "newSkill_fireBall";
        }
    }

    public override string SkillName
    {
        get
        {
            return "火球";
        }
    }
    public override modifier[] mods
    {
        get
        {
            return new modifier[1] { new mod_1_activeSkill() };
        }
    }
}
