using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_1_countReduceCD : modifier
{
    public float reduce_p = 0;
    public mod_1_countReduceCD(float reducePercentage)
    {
        reduce_p = reducePercentage;
    }
   public void aftSkill(SkillInf skillInf, Dictionary<string, object> skillArgs, unitControler[] tragets)
    {
        if (((comboControler.bonus_kind)skillArgs["bonus"]) == comboControler.bonus_kind.Counter)
        {
            traget.timeLeft -= (int)(traget.StandCoolDown * reduce_p);
        }
    }

    public override void onSkillInit(unitControler owner, Callback4Unit_v2 deleg)
    {
        deleg._AftUseSkill += aftSkill;
    }
}
