using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_burn : CDSkill
{
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0 && owner.traget != null && owner.state.CanSkill;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return 4*owner.data.Now_Attack_Interval; ;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        unitControler[] tragets = new unitControler[1];
        tragets[0] = owner.traget;
        return tragets;
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(true, true, true, new List<string>() { SkillInf.TAG_DAMAGE });

    }

    public override void trigger(Dictionary<string, object> args)
    {
        
    }
}
