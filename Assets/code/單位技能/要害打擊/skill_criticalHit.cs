using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_criticalHit : Skill
{
    void callback(Damage d)
    {
        if(d.kind == Damage.KIND_PHYSICAL)
        {//這個時候creater已經是traget了
            d.creater.takeDamage(new Damage(20,Damage.KIND_REAL,owner,new List<string>() {Damage.TAG_CRITICAL}));
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        information = new SkillInf(false, false, false, new List<string>());
        this.owner = (BasicControler)owner;
        deleg._AftCauseDamage += callback;
    }
}
