using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_lightExplosion : skill_resource
{
    public override string Explanation
    {
        get
        {
            return "对所有敌方角色造成致盲,持续250时间,冷却500时间";
        }
    }

    public override string IconName
    {
        get
        {
            return "Icon/致盲光爆";
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
            return new string[2] { "effection/致盲光爆投射物", "effection/致盲光爆爆炸" };
        }
    }

    public override string ScriptName
    {
        get
        {
            return "newSkill_lightExplosion";
        }
    }

    public override string SkillName
    {
        get
        {
            return "致盲光爆";
        }
    }
    public override buff_Inf[] depends
    {
        get
        {
            return new buff_Inf[1] { new blind_bInf() };
        }
    }
}
