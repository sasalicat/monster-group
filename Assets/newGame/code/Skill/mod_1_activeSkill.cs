using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_1_activeSkill : modifier
{
    public override void onSkillInit(unitControler owner, Callback4Unit_v2 deleg)
    {
        //Timer.main.logInTimer(traget.timePass);
        modifySkillInf();
    }
    public void modifySkillInf()
    {
        traget.information.activeSkill = true;
    }
}
