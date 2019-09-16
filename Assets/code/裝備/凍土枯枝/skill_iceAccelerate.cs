using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_iceAccelerate : Skill
{
    protected virtual void callback(SkillInf skillInf, Dictionary<string, object> skillArgs, ref unitControler[] tragets)
    {
        if (skillInf.tags.Contains(SkillInf.TAG_ICE))
            skillArgs["cooldown_multiple"] = (float)skillArgs["cooldown_multiple"] - 0.25f;
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        deleg._BefUseSkill += callback;
    }
}
