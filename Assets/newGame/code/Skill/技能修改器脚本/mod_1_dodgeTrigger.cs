using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_1_dodgeTrigger : modifier
{
    int now_jcId = -1;
    float percentage = 0;
    public void aftDodge(SkillInf skillInf, Dictionary<string, object> skillArgs)
    {
        if (((int)skillArgs["dice"]) <= percentage * 100f&& now_jcId != ((int)skillArgs["jcId"]))
        {
            now_jcId = ((int)skillArgs["jcId"]);
            ((dynamicSkill)traget).arouse2chain(((comboManager)comboManager.main).ChessBoard, ((int)skillArgs["jcId"]));
            
        }
    }
    public override void onSkillInit(unitControler owner, Callback4Unit_v2 deleg)
    {
        deleg._aftDodge += aftDodge;
    }
    public mod_1_dodgeTrigger(float percentage)
    {
        this.percentage = percentage;
    }

}