using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_GunFu : Skill
{
    protected ChessBoard env;
    protected skill_BaseAttackRemote bonusAttack;
    public void befSkillUsed(SkillInf inf, Dictionary<string, object> skillArgs, unitControler[] tragets)
    {
        if (inf.attack){
            if (env.unitsBehind(tragets[0]).Length > 0 && !(bool)skillArgs["bonus"])
            {
                skillArgs["phy_damage_multiple"] = (float)skillArgs["phy_damage_multiple"] - 0.4f;
            }
        }

    }
    public void aftSkillUsed(SkillInf inf, Dictionary<string, object> skillArgs, unitControler[] tragets)
    {
        //Debug.Log("槍鬥術觸發");
        if (tragets[0] != null&&env.units.Contains(tragets[0]))
        {
            if (inf.attack)
            {
                unitControler[] backs = env.unitsBehind(tragets[0]);
                if (backs.Length > 0 && !(bool)skillArgs["bonus"])
                {
                    Dictionary<string, object> args = owner.createSkillArg(owner.data);
                    args["phy_damage_multiple"] = 0.6f;
                    args["bonus"] = true;
                    owner.useSkill(bonusAttack, new unitControler[1] { backs[0] }, args);//主要目標背後的第一個單位選為攻擊目標
                }
            }
        }

    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        information = (SkillInf.passiveSkillInf());
        bonusAttack= gameObject.AddComponent<skill_BaseAttackRemote>();//skill_GunFu自己維護的遠程攻擊技能
        bonusAttack.onInit(owner, deleg);
        env = (ChessBoard)this.owner.env;
        deleg._BefUseSkill += befSkillUsed;
        deleg._AftUseSkill += aftSkillUsed;
    }
}
