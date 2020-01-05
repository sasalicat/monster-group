using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_VampireSpell_crit : resource_VampireSpell
{
    public override string SkillName
    {
        get
        {
            return "吸血魔咒-暴擊";
        }
    }
    public override modifier[] mods
    {
        get
        {
            return new modifier[2] { new mod_1_activeSkill(), new mod_1_critReduceCD(0.4f * TriggerAmend.CRIT) };
        }
    }

}
