using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_snakeShoot : skill_BaseAttackRemote
{
    protected override void ActionForTraget(unitControler traget)
    {
        Dictionary<string, object> args = new Dictionary<string, object>();
        args["layer"] = 2;
        args["time"] = 2.5f;
        args["creater"] = owner;
        traget.addBuff("buff_poison", args);
    }
    protected override Damage createDamage(Dictionary<string, object> skillArg)
    {
        int num = (int)(10 * (float)skillArg[Skill.ARG_PHY_MUL]) + (int)skillArg[Skill.ARG_PHY_ADD];
        List<string> tag = new List<string>() { Damage.TAG_REMOTE };
        if ((bool)skillArg["critical"])
        {
            tag.Add("critical");
        }
        return new Damage(num, Damage.KIND_PHYSICAL, owner, tag);
    }
    protected override Vector2 offset
    {
        get
        {
            return new Vector2(0, 1);
        }
    }
    protected override int missileNo
    {
        get
        {
            return 34;
        }
    }
    protected override int effNo_hit
    {
        get
        {
            return 35;
        }
    }
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
            return 4 * owner.data.Now_Attack_Interval;
        }
    }

}
