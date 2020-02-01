using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSkill_magicShield :dynamicSkill
{
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
            return 4f * BASE_SKILL_COOLDOWN_FRAMES;
        }
    }

    public override unitControler[] getTragets(Environment env)
    {
        return new unitControler[1] { owner };
    }

    public override SkillInf Inf()
    {
        return new SkillInf_v2(this, true, true, false, true, new List<string>() { "heal" });
    }
    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];
        //GameObject effect = resourcePool[prefabNames[0]];
        closeupStage.main.display_anim(Owner, AnimCodes.MAGIC);
        foreach (comboControler traget in tragets)
        {
            Dictionary<string, object> barg = new Dictionary<string, object>();
            barg["time"] = unitData_v2.BASE_ABILITY_NUMBER * 5f;
            barg["num"] = ((comboControler)Owner).data.Now_Mag_Reinforce * 4;
            Owner.addBuff("magicShield_bInf",barg);
        }
        setTime(args);
    }
}
