using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_DeityShelterr : Skill {
    unitData data;
    float percentBefore = 1;
    public void onHpChange(int nowHp)
    {
        float percent = nowHp/ data.Now_Max_Life;
        int recover = (int)((1 - percent) * 10);

        int recoverBef = (int)((1 - percentBefore) * 10);
        data.Now_Life_Recover -= recoverBef;
        data.Now_Life_Recover += recover;
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        data= ((BasicControler)owner).data;
    }


}
