using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSkill_bloodLetting : dynamicSkill
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
        Damage_v2 damage = (Damage_v2)args["damage"];
        comboControler traget = (comboControler)args["traget"]; 

        Dictionary<string, object> bargs = new Dictionary<string, object>();
        bargs["totalNum"] = owner.data.Now_Attack;
        bargs["time"] = 300f;
        traget.addBuff("bleed_bInf", bargs);
    }
}
