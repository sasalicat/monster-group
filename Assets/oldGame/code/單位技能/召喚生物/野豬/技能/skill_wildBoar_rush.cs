using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_wildBoar_rush : CDSkill
{
    protected bool activation = false;
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0&& owner.state.CanSkill;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return 4 * unitData.STAND_ATK_INTERVAL;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        BasicControler[] traget = new BasicControler[1];
        traget[0] = owner;
        return traget;
    }
    void aftSkill(SkillInf inf,Dictionary<string,object> dic,unitControler[] tragets)
    {
        if (inf.attack && !(bool)dic["miss"] && activation) {
            foreach(unitControler traget in tragets)
            {
                traget.addBuff("buff_stun", new Dictionary<string, object>() { { "time", 1.5f } });
            }
            activation = false;
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(true, true, false, new List<string>() { SkillInf.TAG_BUFF });
        this.owner._aftUseSkill += aftSkill;
    }

    public override void trigger(Dictionary<string, object> args)
    {
        activation = true;
    }
}
