using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_1_critTrigger : modifier
{
    int now_jcId=-1;
    float percentage = 0;
    public void aftCrit(Damage d)
    {
        Damage_v2 d_v2 = (Damage_v2)d;
        if (((int)d_v2.extraArgs["dice"]) <= percentage * 100f && now_jcId != ((int)d_v2.extraArgs["jcId"]))
        {
            now_jcId = ((int)d_v2.extraArgs["jcId"]);
            ((dynamicSkill)traget).arouse2chain(((comboManager)comboManager.main).ChessBoard, ((int)d_v2.extraArgs["jcId"]));

        }
    }
    public override void onSkillInit(unitControler owner, Callback4Unit_v2 deleg)
    {
        deleg._aftCrit += aftCrit;
    }
    public mod_1_critTrigger(float percentage)
    {
        this.percentage = percentage;
    }

}