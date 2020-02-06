using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_dismemberment : skill_resource
{
    public override string Explanation
    {
        get
        {
            return "造成300%力量的物理傷害,目標上每有一個負面效果這個傷害增加200%力量";
        }
    }

    public override string IconName
    {
        get
        {
            return "Icon/肢解";
        }
    }

    public override modifier[] mods
    {
        get
        {
            return new modifier[1] {new mod_1_activeSkill()};
        }
    }

    public override string[] prafebList
    {
        get
        {
            return new string[1] { "effection/打擊效果3" };
        }
    }

    public override string ScriptName
    {
        get
        {
            return "newSkill_dismemberment";
        }
    }

    public override string SkillName
    {
        get
        {
            return "肢解";
        }
    }
}
