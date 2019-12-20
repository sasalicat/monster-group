﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSkill_fireBall : dynamicSkill
{
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return 3 * unitData.STAND_ATK_INTERVAL;
        }
    }



    public override unitControler[] getTragets(Environment env)
    {
        Randomer.main.getInt();
        int oppNo = (owner.playerNo + 1) % 2;
        List<comboControler> oppTeam = getAliveEnemy((ChessBoard)env);//((ChessBoard)env).getTeamOf(oppNo);
        if (oppTeam.Count == 0)
        {
            return new unitControler[0];
        }
        else
        {
            unitControler traget = oppTeam[oppNo % (oppTeam.Count)];
            return new unitControler[1] { traget };
        }
    }

    public override SkillInf Inf()
    {
        return new SkillInf_v2(this, true, true, true, true, new List<string>() { "damage" });
    }
    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];
        if (tragets.Length > 0)
        {
            closeupStage.main.display_anim(owner, AnimCodes.MAGIC);
            Dictionary<comboControler, bool> missDict = (Dictionary<comboControler, bool>)args["miss"];
            //comboControler.bonus_kind kind = (comboControler.bonus_kind)args["bonus"];
            GameObject[] resources = dynamicSkill.resourcePool[poolKey];
            foreach (comboControler traget in tragets)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                closeupStage.main.display_effect(resources[0], owner, dict, false);
                if (!missDict[traget])
                {
                    
                    Damage_v2 d = createDamage(owner.data.Now_Mag_Reinforce*3, Damage.KIND_MAGICAL, args);

                    dict["traget"] = traget;
                    dict["creater"] = owner;
                    //dict["damage"] = d;
                    //dict["callback"] = (BasicDelegate.withBasicDict)missile_callback;
                    //dict["effect"] = resources[1];
                    
                    
                    closeupStage.main.display_effect(resources[1], owner, dict, true);
                    traget.takeDamage(d);
                    //Debug.LogWarning("對" + traget.gameObject.name + "造成傷害" + d.num + "點");
                    
                    closeupStage.main.display_anim(traget, AnimCodes.BEHIT);
                }

            }
        }
        setTime(args);

    }
}
