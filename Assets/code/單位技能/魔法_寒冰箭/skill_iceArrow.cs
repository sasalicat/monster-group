using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_iceArrow : skill_BaseAttackRemote {
    protected override int missileNo
    {
        get
        {
            return 24;
        }
    }
    protected override int effNo_hit
    {
        get
        {
            return 25;
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
            return owner.data.Now_Attack_Interval * 2;
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(true, true, false, new List<string>() { SkillInf.TAG_DAMAGE,SkillInf.TAG_ICE });
    }
    protected override Damage createDamage(Dictionary<string, object> skillArg)
    {
        int num =5;
        List<string> tag = new List<string>() { Damage.TAG_ICE, Damage.TAG_REMOTE };
        if ((bool)skillArg["critical"])
        {
            tag.Add("critical");
        }
        Damage damage = new Damage((int)(num * (float)skillArg[Skill.ARG_MAG_MUL] + (int)skillArg[Skill.ARG_MAG_ADD]), Damage.KIND_MAGICAL, owner, tag);

        return damage;
    }
    protected override void ActionForTraget(unitControler traget)
    {
        Dictionary<string, object> args = new Dictionary<string, object>();
        args["time"] = 2f;
        args["layer"] = 1;
        args["creater"] = owner;
        ((BasicControler)traget).addBuff("buff_chill",args);
    }
}
