using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_ArmorBreak : Skill
{
    public void aftSkill(SkillInf skillInf, Dictionary<string, object> skillArgs, unitControler[] tragets)
    {
        if (skillInf.attack && !(bool)skillArgs["miss"])
        {
            foreach(unitControler traget in tragets)
            {
                Dictionary<string, object> buffArg = new Dictionary<string, object>();
                buffArg["time"] = 2.5f*unitData.STAND_ATK_INTERVAL;
                buffArg["num"] = 50;
                ((BasicControler)traget).addBuff("buff_ArmorBreak",buffArg);
            }
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner =  (BasicControler)owner;
        information = SkillInf.passiveSkillInf();
        deleg._AftUseSkill += aftSkill;
    }
}
