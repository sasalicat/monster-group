using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_lightingChain_batter : resource_lightingChain
{
    public override modifier[] mods
    {
        get
        {
            return new modifier[2] { new mod_1_activeSkill(), new mod_1_batterReduceCD(0.4f * TriggerAmend.BATTER) };
        }
    }
    public override string SkillName
    {
        get
        {
            return "閃電鏈-連擊";
        }
    }
}