using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_mysticCurse: skill_resource
{
    public override string Explanation
    {
        get
        {
            return "受到英雄的魔法型技能影響的敵人受到,2層虛弱持續300時間";
        }
    }

    public override string IconName
    {
        get
        {
            return "Icon/秘法詛咒";
        }
    }

    public override string[] prafebList
    {
        get
        {
            return new string[0] { };
        }
    }

    public override string ScriptName
    {
        get
        {
            return "newSkill_mysticCurse";
        }
    }

    public override string SkillName
    {
        get
        {
            return "秘法詛咒";
        }
    }
    public override modifier[] mods
    {
        get
        {
            return new modifier[1] { new mod_1_aftUseSkillTrigger() };
        }
    }
    public override buff_Inf[] depends
    {
        get
        {
            return new buff_Inf[1] { new weak_bInf() };
        }
    }
}


