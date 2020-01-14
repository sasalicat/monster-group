using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSkill_lightingChain : dynamicSkill
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
            return 3f * BASE_SKILL_COOLDOWN_FRAMES;
        }
    }



    public override unitControler[] getTragets(Environment env)
    {
        Randomer.main.getInt();
        int oppNo = (owner.playerNo + 1) % 2;
        List<comboControler> oppTeam = getAliveEnemy((ChessBoard)env);//((ChessBoard)env).getTeamOf(oppNo);
        if (oppTeam.Count <= 3)
        {
            return oppTeam.ToArray();
        }
        else
        {
            comboControler[] tragets = new comboControler[3];
            for (int i = 0; i < tragets.Length; i++)
            {
                int index = Randomer.main.getInt() % oppTeam.Count;
                tragets[i] = oppTeam[index];
                oppTeam.RemoveAt(index);
            }
            return tragets;
        }
    }

    public override SkillInf Inf()
    {
        return new SkillInf_v2(this, false, true, false, true, new List<string>() { "damage","magic" });
    }
    public override void setTime(Dictionary<string, object> args)
    {
        if (((comboControler.bonus_kind)args["bonus"]) == comboControler.bonus_kind.NoBonus)
        {
            base.setTime(args);
        }
    }
    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];

        if (tragets.Length > 0)
        {
            closeupStage.main.display_anim(owner, AnimCodes.MAGIC);
            Dictionary<comboControler, bool> missDict = (Dictionary<comboControler, bool>)args["miss"];
            //comboControler.bonus_kind kind = (comboControler.bonus_kind)args["bonus"];
            //GameObject[] resources = dynamicSkill.resourcePool[poolKey];
            GameObject missile = resourcePool[prefabNames[0]];
            GameObject expro = resourcePool[prefabNames[1]];
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["tragets"] = tragets;
            dict["creater"] = (comboControler)owner;
            closeupStage.main.display_effect(missile, dict, false);
            foreach (comboControler traget in tragets)
            {
                if (!missDict[traget])
                {

                    Damage_v2 d = createDamage(owner.data.Now_Mag_Reinforce * 3 / tragets.Length, Damage.KIND_MAGICAL, args);

                    Dictionary<string, object> dict_expr = new Dictionary<string, object>();
                    dict_expr["traget"] = traget;
                    dict_expr["creater"] = (comboControler)owner;
                    closeupStage.main.display_effect(expro, dict_expr, true);
                    traget.takeDamage(d);

                    closeupStage.main.display_anim(traget, AnimCodes.BEHIT);
                }

            }
        }
        setTime(args);
    }
}
