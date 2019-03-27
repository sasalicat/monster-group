using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_Brutal : Skill
{
    public void befSkill(SkillInf skillInf,Dictionary<string,object> args,unitControler[] tragets)
    {
        BasicControler traget = (BasicControler)tragets[0];
        if (skillInf.attack&& ((float)traget.data.Now_Life/(float)traget.data.Now_Max_Life)<=0.5f)
        {
            args["phy_damage_multiple"] = (float)args["phy_damage_multiple"]+ 0.5f;
            args["critical"] = true;
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        information = SkillInf.passiveSkillInf();
        deleg._BefUseSkill = befSkill;
    }

}
