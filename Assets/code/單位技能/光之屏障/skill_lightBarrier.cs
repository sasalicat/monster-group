using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_lightBarrier : Skill
{
     ChessBoard env;
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        information = SkillInf.passiveSkillInf();
        env=(ChessBoard)((BasicControler)owner).env;
    }
    public override void onEnvReady(Manager manager)
    {
        unitControler[] team = env.teammateOf(owner);
        foreach(BasicControler unit in team)
        {
            Dictionary<string, object> buff_arg = new Dictionary<string, object>();
            buff_arg["num"] = (int)(((BasicControler)owner).data.Now_Mag_Reinforce / 2);
            //Debug.LogWarning("arg[num]設置為:" + buff_arg["num"]);
            buff_arg["time"] =9487f;
            buff_arg["creater"] = owner;
            unit.addBuff("buff_endlessShield", buff_arg);
        }
    }
}
