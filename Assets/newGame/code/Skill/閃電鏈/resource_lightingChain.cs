using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_lightingChain : skill_resource
{
    public override string Explanation
    {
        get
        {
            return "對最多3個目標造成合計30點電系傷害";
        }
    }

    public override string IconName
    {
        get
        {
            return "Icon/閃電鏈";
        }
    }

    public override string[] prafebList
    {
        get
        {
            return new string[2] { "effection/閃電鏈物件", "effection/爆炸特效1" };
        }
    }

    public override string ScriptName
    {
        get
        {
            return "newSkill_lightingChain";
        }
    }

    public override string SkillName
    {
        get
        {
            return "閃電鏈";
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

