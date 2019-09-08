using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_lightEnvoy : Skill
{
    public void befSkill(SkillInf skillInf, Dictionary<string, object> skillArgs, ref unitControler[] tragets)
    {
        skillArgs["healing_multiple"] = (float)skillArgs["healing_multiple"] + 0.3f;
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        information = SkillInf.passiveSkillInf();
        ((BasicControler)owner).data.Now_Life_Recover += 2;
        deleg._BefUseSkill += befSkill;

    }
}
