using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_SensiTechnique : Skill
{
    public void beAppoint(SkillInf inf,Dictionary<string,object> skillArg)
    {
        int dice = ((int)skillArg["dice"]);
        if (dice>=25 && dice <= 45)//20%幾率miss
        {
            skillArg["miss"] = true;
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        deleg._BeAppoint += beAppoint;
    }
}
