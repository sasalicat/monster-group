using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_notherSabre : Skill
{
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        Dictionary<string, object> buffArg = new Dictionary<string, object>();
        buffArg["time"] = 4f;
        buffArg["number"] = 50;
        ((BasicControler)owner).addBuff("buff_Brisk", buffArg);
        information = SkillInf.passiveSkillInf();
    }
}
