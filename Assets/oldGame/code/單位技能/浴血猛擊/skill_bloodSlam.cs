using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_bloodSlam : skill_BaseAttack {
    public override int effNo
    {
        get
        {
            return -1;//沒有攻擊特效
        }
    }
    public override int effNo_hit
    {
        get
        {
            return 46;
        }
    }
    public override unitControler[] findTraget(Environment env)
    {
        return ((ChessBoard)env).getDist1Of(owner.traget,true);
    }
    public override void actionTo(unitControler[] tragets, Dictionary<string, object> skillArg)
    {
        int maxHp = (owner).data.Now_Max_Life;
        Damage d0 = new Damage((int)(maxHp*0.1f),Damage.KIND_REAL,owner);
        owner.takeDamage(d0);
        List<string> tag = new List<string>() { Damage.TAG_ATTACK, Damage.TAG_CLOSE };
        if ((bool)skillArg["critical"])
        {
            tag.Add(Damage.TAG_CRITICAL);
        }
        Damage d1 = new Damage((int)(maxHp * 0.2f * (float)skillArg[Skill.ARG_PHY_MUL] + (int)skillArg[Skill.ARG_PHY_ADD]), Damage.KIND_PHYSICAL, owner,tag);
        tragets[0].takeDamage(d1);
        Damage d2 = new Damage((int)(maxHp * 0.1f * (float)skillArg[Skill.ARG_PHY_MUL] + (int)skillArg[Skill.ARG_PHY_ADD]), Damage.KIND_PHYSICAL, owner,tag);
        for (int i = 1; i < tragets.Length; i++) {
            tragets[i].takeDamage(d2);
        }
    }
    public override float StandCoolDown
    {
        get
        {
            return unitData.STAND_ATK_INTERVAL*5;
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        base.onInit(owner, deleg);
        information = new SkillInf(false,true,false,new List<string>() {SkillInf.TAG_DAMAGE});
    }
}
