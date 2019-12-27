using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_stunAttack : skill_resource
{
    public override string Explanation
    {
        get
        {
            return "主動使用基礎攻擊有66%幾率眩暈目標100時間";
        }
    }

    public override string ScriptName {
        get
        {
            return "newSkill_stunAttack";
        }
    }

    public override string SkillName
    {
        get
        {
            return "眩暈擊";
        }
    }

    public override string[] prafebList {
        get
        {
            return new string[0] {};
        }
    }
    public override string IconName
    {
        get
        {
            return "Icon/火球";
        }
    }

    public override modifier[] mods {
        get
        {
            return new modifier[1]{ new mod_1_baseAttackTrigger(1* TriggerAmend.BASE_ATTACK) };
        }
    }
    public override buff_Inf[] depends
    {
        get
        {
            return new buff_Inf[1] {new stun_bInf()};
        }
    }
}
