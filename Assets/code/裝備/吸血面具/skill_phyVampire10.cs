using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_phyVampire10 : Skill {
    public void callback(Damage d)
    {
        if (d.kind ==Damage.KIND_PHYSICAL)
        {
            owner.data.Now_Life += (int)(d.num * 0.1);
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        deleg._AftCauseDamage += callback;
        this.owner = (BasicControler)owner;
    }
}
