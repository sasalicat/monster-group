using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_1_countTrigger : modifier {
    int now_jcId = -1;
    float percentage = 0;
    public void aftSkill(SkillInf skillInf, Dictionary<string, object> skillArgs, unitControler[] tragets)
    {
        if (((comboControler.bonus_kind)skillArgs["bonus"]) == comboControler.bonus_kind.Counter)
        {
            if (((int)skillArgs["dice"]) <= percentage * 100f&&((int)skillArgs["jcId"])!=now_jcId)
            {
                now_jcId = ((int)skillArgs["jcId"]);
                ((dynamicSkill)traget).arouse2chain(((comboManager)comboManager.main).ChessBoard, ((int)skillArgs["jcId"]));

            }
        }
    }
    public override void onSkillInit(unitControler owner, Callback4Unit_v2 deleg)
    {
        deleg._AftUseSkill += aftSkill;
    }
    public mod_1_countTrigger(float percentage)
    {
        this.percentage = percentage;
    }

}
