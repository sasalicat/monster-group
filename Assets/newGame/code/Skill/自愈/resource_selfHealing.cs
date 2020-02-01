using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_selfHealing : skill_resource
{
    public override string Explanation
    {
        get
        {
            return "英雄恢復等於其30%生命上限的生命值,隨機驅散自身結付的1個負面效果";
        }
    }

    public override string IconName
    {
        get
        {
            return "Icon/自愈";
        }
    }

    public override modifier[] mods
    {
        get
        {
            return new modifier[1] { new mod_1_activeSkill() };
        }
    }

    public override string[] prafebList
    {
        get
        {
            return new string[1] { "effection/自愈特效" };
        }
    }

    public override string ScriptName
    {
        get
        {
            return "newSkill_selfHealing";
        }
    }

    public override string SkillName
    {
        get
        {
            return "自愈";
        }
    }
}
