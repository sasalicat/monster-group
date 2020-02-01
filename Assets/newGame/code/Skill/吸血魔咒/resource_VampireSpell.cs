using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_VampireSpell : skill_resource {
    public override string Explanation
    {
        get
        {
            return "造成10點魔法傷害,自身恢復10點生命值";
        }
    }

    public override string IconName
    {
        get
        {
            return "Icon/吸血魔咒";
        }
    }

    public override string[] prafebList
    {
        get
        {
            return new string[3] { "effection/血魔法", "effection/血噴發", "effection/吸血恢復特效" };
        }
    }

    public override string ScriptName
    {
        get
        {
            return "newSkill_VampireSpell";
        }
    }

    public override string SkillName
    {
        get
        {
            return "吸血魔咒";
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
