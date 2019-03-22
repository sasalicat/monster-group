using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_ShieldBlock : Skill
{
    public void callback(Damage damage)
    {
        if(damage.kind != Damage.KIND_REAL)
        {
           
            int pointer= Randomer.main.getInt();
            if (pointer<50) {
                GameObject effection = Instantiate(objectList.main.prafebList[7], owner.transform);
                effection.transform.localPosition = Vector2.zero;
                if (damage.num > 5)
                {
                    damage.num -= 5;
                }
                else
                {
                    damage.num = 0;
                }
            }
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        information = new SkillInf(false, false, false, new List<string>());
        this.owner = (BasicControler)owner;
        deleg._BefTakeDamage += callback;
    }
}
