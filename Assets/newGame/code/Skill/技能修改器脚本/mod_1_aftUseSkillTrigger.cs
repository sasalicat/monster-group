using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_1_aftUseSkillTrigger : modifier
{
    public override void onSkillInit(unitControler owner, Callback4Unit_v2 deleg)
    {
        deleg._AftUseSkill += callback;
    }
    public void callback(SkillInf skinf,Dictionary<string,object> skillArgs,unitControler[] tragets)
    {
        skillArgs["skillInf"] = skinf;
        traget.trigger(skillArgs);
    }
}
