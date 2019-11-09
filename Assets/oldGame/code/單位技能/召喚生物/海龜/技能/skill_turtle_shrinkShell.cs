using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_turtle_shrinkShell : CDSkill {
    public const int STAND_SHEILD_NUM = 100;
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0 && owner.traget != null && owner.state.CanSkill;
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
        return new unitControler[] {owner};
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(true, true, false, new List<string>() { SkillInf.TAG_DAMAGE });
    }

    public override void trigger(Dictionary<string, object> args)
    {
        int num = (int)(STAND_SHEILD_NUM * (float)args[Skill.ARG_MAG_MUL] + (int)args[Skill.ARG_MAG_ADD]);
        Dictionary<string, object> barg = new Dictionary<string, object>();
        barg["num"] = num;
        barg["time"] = 4f;
        barg["creater"] = owner;
        owner.addBuff("buff_shrinkShell",barg);
        setTime(args);
    }

}
