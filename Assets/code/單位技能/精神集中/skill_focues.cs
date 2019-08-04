using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_focues : Skill
{
    public void onHpChange(int before)
    {

        int max_hp = this.owner.data.Now_Max_Life;
        int now_hp = this.owner.data.Now_Life;
        float percent = ((float)now_hp) / ((float)max_hp);

        float percent_before = ((float)before) / ((float)max_hp);
        if (percent_before >= 0.5f && percent < 0.5f)
        {
            owner.data.Now_Mag_Reinforce -= 80;
        }
        else if (percent_before<0.5f&& percent>=0.5f) {
            owner.data.Now_Mag_Reinforce += 80;
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        information = new SkillInf(false, false, false, new List<string>());
        this.owner = (BasicControler)owner;
        deleg._onHpChange += onHpChange;
        int max_hp = this.owner.data.Now_Max_Life;
        int now_hp = this.owner.data.Now_Life;
        float percent = ((float)now_hp) / ((float)max_hp);
        if(percent >= 0.5)
        {
            this.owner.data.Now_Mag_Reinforce += 80;
        }
    }
}
