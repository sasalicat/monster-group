using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_dropWeapon : CDSkill
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
            return 4.5f * unitData.STAND_ATK_INTERVAL;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        return new unitControler[1]{ owner.traget};
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(true, true, false, new List<string>() { SkillInf.TAG_CONTROL });
    }

    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];
        if (!(bool)args["miss"]) {

            foreach(BasicControler traget in tragets)
            {
                Dictionary<string, object> barg = new Dictionary<string, object>();
                barg["time"] = 2.5f;
                traget.addBuff("buff_disarm",barg);
            }
        }
        else
        {
            BasicControler traget = (BasicControler)tragets[0];
            NumberCreater.main.CreateMissing(traget.transform.position);
        }
        setTime();
    }
}
