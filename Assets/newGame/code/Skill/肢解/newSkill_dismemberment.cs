using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSkill_dismemberment : dynamicSkill
{
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0 && owner.state.CanAttack;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return 1.5f * BASE_SKILL_COOLDOWN_FRAMES;
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
            int traget_debuffNum=0;
            comboControler traget = oppTeam[0];
            foreach(comboControler unit in oppTeam)
            {
                int debuffNum = 0;
                foreach (Buff buff in unit.buffList)
                {
                    if (buff.kind == Buff.NEGATIVE)
                    {
                        debuffNum++;
                    }
                }
                if (debuffNum > traget_debuffNum)
                {
                    traget = unit;
                    traget_debuffNum = debuffNum;
                }
            }
            return new unitControler[1] { traget };
        }
    }

    public override SkillInf Inf()
    {
        return new SkillInf_v2(this, true, true, false, false, new List<string>() { "damage" });
    }

    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];
        if (tragets.Length > 0)
        {
            closeupStage.main.display_anim(owner, AnimCodes.ATTACK);
            Dictionary<comboControler, bool> missDict = (Dictionary<comboControler, bool>)args["miss"];
            //comboControler.bonus_kind kind = (comboControler.bonus_kind)args["bonus"];

            foreach (comboControler traget in tragets)
            {
                if (!missDict[traget] && !traget.data.Dead)
                {
                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    dict["traget"] = traget;
                    dict["creater"] = owner;
                    //GameObject[] resources= dynamicSkill.resourcePool[poolKey];
                    GameObject eff = resourcePool[prefabNames[0]];
                    closeupStage.main.display_effect(eff, dict, true);
                    int debuffNum = 0;
                    foreach (Buff buff in traget.buffList) {
                        if(buff.kind  == Buff.NEGATIVE)
                        {
                            debuffNum++;
                        }
                    }
                    Damage_v2 d = createDamage(owner.data.Now_Attack*(3+2*debuffNum), Damage.KIND_PHYSICAL, args);
                    //Debug.LogWarning("對" + traget.gameObject.name + "造成傷害" + d.num + "點");
                    traget.takeDamage(d);
                    if (!traget.data.Dead)
                    {
                        closeupStage.main.display_anim(traget, AnimCodes.BEHIT);
                    }
                }

            }
        }
        setTime(args);

    }

}