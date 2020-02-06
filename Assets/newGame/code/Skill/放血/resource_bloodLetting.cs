using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_bloodLetting : skill_resource
{
    public override string Explanation
    {
        get
        {
            return "在造成物理傷害后,對目標造成等於力量*1的流血,在300時間內每50時間造成1/6的總傷害";
        }
    }

    public override string IconName
    {
        get
        {
            return "Icon/放血";
        }
    }

    public override modifier[] mods
    {
        get
        {
            return new modifier[1] { new mod_1_phyDamageTrigger(1f) };
        }
    }

    public override string[] prafebList
    {
        get
        {
            return new string[0] {};
        }
    }

    public override string ScriptName
    {
        get
        {
            return "newSkill_bloodLetting";
        }
    }

    public override string SkillName
    {
        get
        {
            return "放血";
        }
    }
    public override buff_Inf[] depends
    {
        get
        {
            return new buff_Inf[1] { new bleed_bInf() };
        }
    }
}
