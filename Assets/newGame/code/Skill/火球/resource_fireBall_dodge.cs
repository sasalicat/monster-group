using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_fireBall_dodge : resource_fireBall {
    public override modifier[] mods
    {
        get
        {
            return new modifier[2] { new mod_1_activeSkill(), new mod_1_dodgeReduceCD(0.4f * TriggerAmend.DODGE) };
        }
    }
    public override string SkillName
    {
        get
        {
            return "火球-閃避";
        }
    }
}
