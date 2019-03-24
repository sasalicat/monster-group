using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_Slam : skill_BaseAttack {
    public override int effNo
    {
        get
        {
            return -1;
        }
    }
    public override int effNo_hit
    {
        get
        {
            return 5;
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
            return 6f;
        }
    }
    public override void actionTo(unitControler[] tragets, Dictionary<string, object> skillArg)
    {
        float multip=(float)skillArg["phy_damage_multiple"];
        int add = (int)skillArg["phy_damage_addition"];
        Damage d = new Damage((int)(5 * multip + add), Damage.KIND_PHYSICAL, owner);
        tragets[0].takeDamage(d);
        multip = (float)skillArg["control_multiple"];
        float time =2 * unitData.STAND_ATK_INTERVAL *multip;
        Dictionary<string, object> buffArg = new Dictionary<string, object>();
        buffArg["time"] = time;
        tragets[0].addBuff("buff_stun",buffArg);
    }

}
