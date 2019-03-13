using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_WildForce : Skill {
    unitData data;
    float percentBefore = 1;
    public void onHpChange(int nowhp)
    {
        float percent = nowhp / data.Now_Max_Life;
        if(percentBefore>0.5f && percent <= 0.5f)
        {
            data.Now_Attack += 5;
            data.Now_Life_Recover += 5;
        }
        else if(percentBefore<=0.5f && percent>0.5)
        {
            data.Now_Attack -= 5;
            data.Now_Life_Recover -= 5;
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        data = ((BasicControler)owner).data;
        deleg._onHpChange += onHpChange;  
    }

}
