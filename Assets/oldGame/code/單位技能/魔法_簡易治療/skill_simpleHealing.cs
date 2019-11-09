using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_simpleHealing : CDSkill
{
    public const int HEALING_POINT = 10;
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
            return 2 * unitData.STAND_ATK_INTERVAL;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        BasicControler[] teammate=(BasicControler[])((ChessBoard)env).teammateOf(owner);
        BasicControler best = teammate[0];
        int bestHurt = best.data.Now_Max_Life - best.data.Now_Life;
        foreach (BasicControler traget in teammate) {
            int hurt = traget.data.Now_Max_Life - traget.data.Now_Life;
            if (hurt > bestHurt) {
                best = traget;
                bestHurt = hurt;
            }
        }
        return new unitControler[1] { best };
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(true,true,false,new List<string>() {SkillInf.TAG_CURE,SkillInf.TAG_HOLY});
    }

    public override void trigger(Dictionary<string, object> args)
    {
        int num = (int)(HEALING_POINT * (float)args[Skill.ARG_HEAL_MUL]) + (int)args[Skill.ARG_HEAL_ADD];
        unitControler[] tragets = (unitControler[])args["tragets"];
        if (!(bool)args["miss"])
        {
            foreach (BasicControler traget in tragets) {
                traget.heal(num, owner);
                Instantiate(objectList.main.prafebList[38], traget.transform.position, traget.transform.rotation);
            }
        }
        setTime(args);
    }
}
