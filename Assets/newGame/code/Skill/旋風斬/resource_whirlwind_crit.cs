using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_whirlwind_crit : resource_whirlwind
{
    public override modifier[] mods
    {
        get
        {
            return new modifier[1] { new mod_1_critTrigger(1f) };
        }
    }
    public override string SkillName
    {
        get
        {
            return "暴擊觸發旋風斬";
        }
    }
}