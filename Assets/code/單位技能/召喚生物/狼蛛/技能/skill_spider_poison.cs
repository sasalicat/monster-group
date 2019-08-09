using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_spider_poison : Skill
{
    void aftAttack(SkillInf inf,Dictionary<string,object> skillArgs,unitControler[] tragets)
    {
        if (inf.attack && !(bool)skillArgs["miss"])
        {
            Dictionary<string, object> barg = new Dictionary<string, object>();
            barg["time"] = 2f;
            barg["layer"] = 1;
            barg["creater"] = owner;
            foreach(unitControler traget in tragets)
            {
                if(Randomer.main.getInt() % 100 <= 60){
                    traget.addBuff("buff_poison", barg);
                }
            }
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        information = new SkillInf(false, false, false, new List<string>());
        this.owner = (BasicControler)owner;
        deleg._AftUseSkill += aftAttack;
    }
}
