using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_1_blockReduceCD : modifier {
    public float reduce_p = 0;
    public mod_1_blockReduceCD(float reducePercentage)
    {
        reduce_p = reducePercentage;
    }
    public void aftBlock(Damage d)
    {
        traget.timeLeft -= (int)(traget.StandCoolDown * reduce_p);
    }
    public override void onSkillInit(unitControler owner, Callback4Unit_v2 deleg)
    {
        deleg._aftBlock += aftBlock;
    }

}
