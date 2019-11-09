using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_BluntUser : Skill {
    protected float stun_time = 1.3f;
    public void callback(SkillInf skillInf, Dictionary<string, object> skillArgs,ref unitControler[] tragets) {
        Debug.Log("blunt user callback被觸發:"+skillInf.attack);
        if (skillInf.attack) {
            int rpoint = Randomer.main.getInt();
            Debug.Log("rpoint:" + rpoint);
            if(rpoint>=71 && rpoint < 91)
            {
                Dictionary<string, object> arg = new Dictionary<string, object>();
                arg["time"] = unitData.STAND_ATK_INTERVAL*stun_time;
                foreach (unitControler traget in tragets) {
                    
                    ((BasicControler)traget).addBuff("buff_stun",arg);
                }
            }
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        information = new SkillInf(false,false,false,new List<string>());
        this.owner = (BasicControler)owner;
        deleg._BefUseSkill+=callback;
        //int point = Randomer.main.getInt();
    }
}
