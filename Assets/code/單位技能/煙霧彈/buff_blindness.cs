using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_blindness : Buff {
    public override float Duration
    {
        get
        {
            return 0;
        }
    }
    public void missJudge(SkillInf skillInf, Dictionary<string, object> skillArgs, unitControler[] tragets)
    {
        if (skillInf.singleTraget)
        {
            int point = Randomer.main.getInt();
            if (point < 50)
            {
                Debug.Log("missJudge 被觸發~~~~~~");
                skillArgs["miss"] = true;
            }
        }
    }
    public override bool onInit(unitControler unit, Buff[] Repetitive, Dictionary<string, object> args)
    {
        float time = (float)args["time"];
        if (Repetitive.Length > 0)
        {
            if (Repetitive[0].timeLeft < time)
            {
                Repetitive[0].timeLeft = time;
            }
            return false;
        }
        else
        {
            this.unit = unit;
            timeLeft = time;
            ((BasicControler)unit)._befUseSkill += missJudge;
            return true;
        }
    }

    public override void onRemove()
    {
        ((BasicControler)unit)._befUseSkill -= missJudge;
    }


}
