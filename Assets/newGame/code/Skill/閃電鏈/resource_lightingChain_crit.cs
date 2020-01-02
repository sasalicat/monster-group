using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_lightingChain_crit : resource_fireBall
{
    public override modifier[] mods
    {
        get
        {
            return new modifier[2] { new mod_1_activeSkill(), new mod_1_critReduceCD(0.4f * TriggerAmend.CRIT) };
        }
    }
    public override string SkillName
    {
        get
        {
            return "閃電鏈-暴擊";
        }
    }
}