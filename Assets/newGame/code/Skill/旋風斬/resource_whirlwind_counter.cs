using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_whirlwind_counter : resource_whirlwind {
    public override modifier[] mods
    {
        get
        {
            return new modifier[1] { new mod_1_countTrigger(0.2f) };
        }
    }
    public override string SkillName
    {
        get
        {
            return "反擊觸發旋風斬";
        }
    }
}
