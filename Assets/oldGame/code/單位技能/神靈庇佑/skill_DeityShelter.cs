using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_DeityShelter : Skill {
    unitData data;
    float percentBefore = 1;
    public void onHpChange(int nowHp)
    {
        float percent = (float)nowHp/ (float)data.Now_Max_Life;
        int recover = (int)((1f - percent) * 10);

        int recoverBef = (int)((1f - percentBefore) * 10);
        data.Now_Life_Recover -= recoverBef;
        data.Now_Life_Recover += recover;
        percentBefore = percent;
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        data= ((BasicControler)owner).data;
        this.information = new SkillInf(true, false, false, new List<string>() { });
        deleg._onHpChange += onHpChange;
    }


}
