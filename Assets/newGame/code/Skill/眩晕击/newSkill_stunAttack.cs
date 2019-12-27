using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSkill_stunAttack : dynamicSkill
{
    public override float StandCoolDown {
        get
        {
            return -1;
        }
    }

    public override bool canUse
    {
        get {
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
        unitControler[] tragets = (unitControler[])args["tragets"];
        foreach(comboControler traget in tragets)
        {
            traget.addBuff("newBuff_stun");
        }
    }
}
