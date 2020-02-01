using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_magicShield : skill_resource
{
    public override string Explanation
    {
        get
        {
            return "獲得1個吸收等於4*魔力傷害的護盾,此技能初始冷卻為0";
        }
    }

    public override string IconName
    {
        get
        {
            return "Icon/魔法盾";
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
            return "newSkill_magicShield";
        }
    }

    public override string SkillName
    {
        get
        {
            return "魔法盾";
        }
    }
    public override modifier[] mods
    {
        get
        {
            return new modifier[2] { new mod_1_activeSkill(),new mod_1_setInitCD(0)};
        }
    }
    public override buff_Inf[] depends
    {
        get
        {
            return new buff_Inf[1] { new magicShield_bInf() };
        }
    }
}