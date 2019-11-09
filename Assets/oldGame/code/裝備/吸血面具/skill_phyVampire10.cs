using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_phyVampire10 : Skill {
    protected virtual float percentage
    {
        get
        {
            return 0.1f;
        }
    }
    public virtual void callback(Damage d)
    {
        if (d.kind ==Damage.KIND_PHYSICAL)
        {
            owner.data.Now_Life += (int)(d.num * percentage);
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        deleg._AftCauseDamage += callback;
        this.owner = (BasicControler)owner;
    }
}
