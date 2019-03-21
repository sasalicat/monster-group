using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_HeavyArmor : Skill
{
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        ((BasicControler)owner).data.Now_Armor += 50;
        information = new SkillInf(false,false,false,new List<string>());
    }
}
