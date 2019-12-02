using System;
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
        return new SkillInf(true,true,true,  new List<string>() { "damage" });
    }

    public override void trigger(Dictionary<string, object> args)
    {
        closeupStage.main.display_anim(owner, roleAnim.ATTACK);
        Dictionary<comboControler, bool> missDict = (Dictionary<comboControler, bool>)args["miss"];
        comboControler.bonus_kind kind = (comboControler.bonus_kind)args["bonus"];
    }

}
