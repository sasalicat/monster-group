using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_holyCross : CDSkill
{
    public const int MAIN_HEALING_POINT = 15;
    public const int SUB_HEALING_POINT = 5;
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0 && owner.state.CanSkill;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return 4 * unitData.STAND_ATK_INTERVAL;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        BasicControler[] teammate = (BasicControler[])((ChessBoard)env).teammateOf(owner);
        BasicControler best = teammate[0];
        int bestHurt = best.data.Now_Max_Life - best.data.Now_Life;
        foreach (BasicControler traget in teammate)
        {
            int hurt = traget.data.Now_Max_Life - traget.data.Now_Life;
            if (hurt > bestHurt)
            {
                best = traget;
                bestHurt = hurt;
            }
        }
        return ((ChessBoard)env).getDist1Of(best, true);


    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(true, true, false, new List<string>() { SkillInf.TAG_CURE });
    }

    public override void trigger(Dictionary<string, object> args)
    {
        
        unitControler[] tragets = (unitControler[])args["tragets"];
        if (!(bool)args["miss"])
        {
            for(int i=0;i<tragets.Length;i++)
            {
                BasicControler traget = (BasicControler)tragets[i];
                int num = (int)(SUB_HEALING_POINT * (float)args[Skill.ARG_HEAL_MUL]) + (int)args[Skill.ARG_HEAL_ADD];
                if (i == 0)
                {
                    num = (int)(MAIN_HEALING_POINT * (float)args[Skill.ARG_HEAL_MUL]) + (int)args[Skill.ARG_HEAL_ADD];
                    Instantiate(objectList.main.prafebList[39], traget.transform.position, traget.transform.rotation);
                }
                traget.heal(num, owner);
                
            }
        }
        setTime();
    }
}
