using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_whirlwind : skill_resource
{
    public override string Explanation
    {
        get
        {
            return "對所有敵人造成50%力量的物理傷害";
        }
    }

    public override string IconName
    {
        get
        {
            return "Icon/旋風斬";
        }
    }

    public override string[] prafebList
    {
        get
        {
            return new string[2] { "effection/旋風斬特效", "effection/打擊效果2" };
        }
    }

    public override string ScriptName
    {
        get
        {
            return "newSkill_whirlwind";
        }
    }

    public override string SkillName
    {
        get
        {
            return "旋風斬";
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