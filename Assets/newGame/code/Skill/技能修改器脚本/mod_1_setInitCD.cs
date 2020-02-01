using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_1_setInitCD : modifier
{
    float percentage = 0;
    public mod_1_setInitCD(float percentage)
    {
        this.percentage = percentage;
    }
    public override void onSkillInit(unitControler owner, Callback4Unit_v2 deleg)
    {
        traget.timeLeft *= percentage;
    }
}
