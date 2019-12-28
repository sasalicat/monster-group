using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_1_baseAttackTrigger : modifier
{
    float percentage = 0;
    public void aftSkill(SkillInf skillInf, Dictionary<string, object> skillArgs, unitControler[] tragets)
    {
        if (skillInf.attack && ((comboControler.bonus_kind)skillArgs["bonus"]) == comboControler.bonus_kind.NoBonus) {
            if (((int)skillArgs["dice"]) <= percentage * 100f) {
                traget.trigger(skillArgs);
            }
        }
    }
    public override void onSkillInit(unitControler owner, Callback4Unit_v2 deleg)
    {
        deleg._AftUseSkill += aftSkill;   
    }
    public mod_1_baseAttackTrigger(float percentage)
    {
        this.percentage = percentage;
    }
}
