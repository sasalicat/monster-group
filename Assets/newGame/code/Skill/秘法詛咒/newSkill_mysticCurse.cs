using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSkill_mysticCurse : dynamicSkill
{
    public override float StandCoolDown
    {
        get
        {
            return -1;
        }
    }

    public override bool canUse
    {
        get
        {
            return false;
        }
    }

    public override unitControler[] getTragets(Environment env)
    {
        return null;
    }

    public override SkillInf Inf()
    {
        return new SkillInf_v2(this);
    }

    public override void trigger(Dictionary<string, object> args)
    {
        SkillInf skinf = (SkillInf)args["skillInf"];
        if (skinf.tags.Contains("magic"))
        {
            Dictionary<comboControler, bool> missDict = (Dictionary<comboControler, bool>)args["miss"];
            unitControler[] tragets = (unitControler[])args["tragets"];
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["time"] = unitData_v2.BASE_ABILITY_NUMBER * 3f;
            arg["layer"] = 2;
            foreach (comboControler traget in tragets)
            {
                if (!missDict[traget])
                    traget.addBuff("weak_bInf", arg);
            }
        }
    }
}
