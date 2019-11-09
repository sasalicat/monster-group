using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_elemAffinity : Skill
{
    public void onCreateBuff(Buff buff,unitControler creater)
    {
        //Debug.LogWarning("skill elem affinity name:"+buff.GetType().ToString());
        if(buff.GetType() == Type.GetType("buff_chill")||buff.GetType() == Type.GetType("buff_palsy")||buff.GetType() == Type.GetType("buff_burn"))
        {
            //Debug.LogWarning("屬於寒冷,麻痺,燃燒");
            buff.timeLeft *= 1.5f;
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        information = new SkillInf(false, false, false, new List<string>());
        this.owner = (BasicControler)owner;
        this.owner.data.Now_Mag_Resistance += 25;
        deleg._onCreateBuff += onCreateBuff;
    }
}
