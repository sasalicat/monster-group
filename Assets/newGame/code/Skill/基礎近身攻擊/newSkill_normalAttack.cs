using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSkill_normalAttack : dynamicSkill {
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0&&owner.state.CanAttack;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return 1 * BASE_SKILL_COOLDOWN_FRAMES;
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
        return new SkillInf_v2(this,true,true,true,false,new List<string>() { "damage" });
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
                if (!missDict[traget])
                {
                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    dict["traget"] = traget;
                    dict["creater"] = owner;
                    //GameObject[] resources= dynamicSkill.resourcePool[poolKey];
                    GameObject eff = resourcePool[prefabNames[0]];
                    closeupStage.main.display_effect(eff,dict,true);

                    Damage_v2 d = createDamage(owner.data.Now_Attack, Damage.KIND_PHYSICAL, args);
                    //Debug.LogWarning("對" + traget.gameObject.name + "造成傷害" + d.num + "點");
                    traget.takeDamage(d);
                    closeupStage.main.display_anim(traget, AnimCodes.BEHIT);
                }

            }
        }
        setTime(args);

    }

}
