﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSkill_normalAttack : dynamicSkill {
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
            return 1 * unitData.STAND_ATK_INTERVAL;
        }
    }

    protected override List<modifier> Modifiers
    {
        get
        {
            return new List<modifier>() {new mod_1_activeSkill()};
        }
    }

    public override unitControler[] getTragets(Environment env)
    {
        Randomer.main.getInt();
        int oppNo = (owner.playerNo + 1) % 2;
        List<unitControler> oppTeam= ((ChessBoard)env).getTeamOf(oppNo);
        unitControler traget = oppTeam[oppNo % (oppTeam.Count)];
        return new unitControler[1] { traget };
    }

    public override SkillInf Inf()
    {
        return new SkillInf_v2(this,true,true,true,false,new List<string>() { "damage" });
    }

    public override void trigger(Dictionary<string, object> args)
    {

        closeupStage.main.display_anim(owner, roleAnim.ATTACK);
        Dictionary<comboControler, bool> missDict = (Dictionary<comboControler, bool>)args["miss"];
        //comboControler.bonus_kind kind = (comboControler.bonus_kind)args["bonus"];
        unitControler[] tragets = (unitControler[])args["tragets"];
        foreach(comboControler traget in tragets)
        {
            if (!missDict[traget])
            {
                Damage_v2 d = createDamage(owner.data.Now_Attack, Damage.KIND_PHYSICAL, args);
                Debug.LogWarning("對" + traget.gameObject.name + "造成傷害" + d.num + "點");
                traget.takeDamage(d);
                closeupStage.main.display_anim(traget, roleAnim.BEHIT);
            }
            
        }

    }

}
