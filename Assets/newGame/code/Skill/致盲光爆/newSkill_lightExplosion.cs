using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSkill_lightExplosion : dynamicSkill {
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
            return 5f * BASE_SKILL_COOLDOWN_FRAMES;
        }
    }

    public override unitControler[] getTragets(Environment env)
    {
        List<comboControler> enemys=getAliveEnemy((ChessBoard)env);
        return enemys.ToArray();
    }

    public override SkillInf Inf()
    {
        return new SkillInf_v2(this, false, true, false, true, 
            new List<string>() { SkillInf_v2.TAG_HOLY, SkillInf_v2.TAG_NUFF });
    }

    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];
        closeupStage.main.display_anim(owner, AnimCodes.MAGIC);

        Dictionary<comboControler, bool> missDict = (Dictionary<comboControler, bool>)args["miss"];

        Dictionary<string, object> bDict = new Dictionary<string, object>();
        bDict["time"] = 2.5f * BASE_SKILL_COOLDOWN_FRAMES;
        Vector2 posSum = Vector2.zero;
        foreach (comboControler traget in tragets)
        {
            if (!missDict[traget]) {
                traget.addBuff("blind_bInf",bDict);
            }
            posSum += closeupStage.main.controler2roleAnim[traget].Center;
        }
        
        GameObject missile = resourcePool[prefabNames[0]];
        Dictionary<string, object> misDict = new Dictionary<string, object>();
        posSum /= tragets.Length;
        misDict["creater"] = owner;
        misDict["destination"] = posSum;
        closeupStage.main.display_effect(missile, misDict, false);

        GameObject expro = resourcePool[prefabNames[1]];
        Dictionary<string, object> expDict = new Dictionary<string, object>();
        expDict["position"] = posSum;
        closeupStage.main.display_effect(expro, expDict, true);
        setTime(args);
    }

}
