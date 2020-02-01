using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSkill_selfHealing : dynamicSkill
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
            return 4f *BASE_SKILL_COOLDOWN_FRAMES;
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
        GameObject effect = resourcePool[prefabNames[0]];
        closeupStage.main.display_anim(Owner, AnimCodes.MAGIC);
        foreach (comboControler traget in tragets)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["traget"] = traget;
            dict["creater"] = owner;
            closeupStage.main.display_effect(effect, dict, false);
            owner.heal((int)(owner.data.Now_Max_Life * 0.3f), owner);
            List<Buff> buffs = owner.buffList;
            List<Buff_v2> debuffs = new List<Buff_v2>();
            foreach (Buff_v2 buff in buffs)
            {
                if (buff.kind == Buff.NEGATIVE)
                {
                    debuffs.Add(buff);
                }
            }
            if (debuffs.Count > 0)//清除一個debuff
            {
                int num = Randomer.main.getInt();
                int index = num % debuffs.Count;
                debuffs[index].dispelSelf();
            }
        }
        setTime(args);
    }
}
