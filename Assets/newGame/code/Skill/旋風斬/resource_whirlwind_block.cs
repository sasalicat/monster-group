using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_whirlwind_block : resource_whirlwind
{
    public override modifier[] mods
    {
        get
        {
            return new modifier[1] { new mod_1_blockTrigger(1f) };
        }
    }
    public override string SkillName
    {
        get
        {
            return "格擋觸發旋風斬";
        }
    }
}