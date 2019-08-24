using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_heavenFire : CDSkill
{
    public int DAMAGE = 15;
    public int HEALING = 15;
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0 && owner.state.CanSkill && owner.traget != null;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return 5 * unitData.STAND_ATK_INTERVAL;
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
        return new unitControler[2] { owner.traget,best };
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(true,true,false,new List<string>() {SkillInf.TAG_CURE,SkillInf.TAG_DAMAGE});
    }
    
    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];
        if (!(bool)args["miss"])
        {
            Instantiate(objectList.main.prafebList[42],((BasicControler)tragets[0]).transform.position, ((BasicControler)tragets[0]).transform.rotation);
            int num = (int)(DAMAGE * (float)args[Skill.ARG_MAG_MUL]) + (int)args[Skill.ARG_MAG_ADD];
            int hnum = (int)(HEALING*(float)args[Skill.ARG_HEAL_MUL] + (int)args[Skill.ARG_HEAL_ADD]);
            Damage d = new Damage(num,Damage.KIND_MAGICAL,owner,new List<string>() {Damage.TAG_REMOTE});
            tragets[0].takeDamage(d);

            tragets[1].heal(hnum, owner);
        }
        setTime();
    }
}
