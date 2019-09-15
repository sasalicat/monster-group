using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_SmokeBomb : CDSkill
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
            return 7 * unitData.STAND_ATK_INTERVAL;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        unitControler[] traget = new unitControler[1];
        traget[0] = owner.traget;
        return traget;
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        information = new SkillInf(false,true,false,new List<string>() {SkillInf.TAG_CONTROL});
    }

    public override void trigger(Dictionary<string, object> args)
    {
       unitControler[] tragets = (unitControler[])args["tragets"];
        BasicControler traget =(BasicControler)((unitControler[])args["tragets"])[0];
        GameObject effection = Instantiate(objectList.main.prafebList[11],traget.transform.position,Quaternion.Euler(0,0,0));
        effection.GetComponent<decisionArea>().time = 2 * unitData.STAND_ATK_INTERVAL;
        Dictionary<string, object> arg = new Dictionary<string, object>();
        arg["time"] = 2 * unitData.STAND_ATK_INTERVAL;
        foreach (BasicControler control in tragets) {
            control.addBuff("buff_blindness",arg);
        }
        setTime(args);
    }
}
