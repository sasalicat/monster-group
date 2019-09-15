using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_FlameWave : CDSkill {
    private readonly int BaseDamageNum = 20;
    private readonly float decay = 0.7f;
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0 && owner.traget != null && owner.state.CanSkill;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return 6 * unitData.STAND_ATK_INTERVAL;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        //Debug.LogWarning("找到的traget數量為:" + ((ChessBoard)env).getColOf(owner).Length);
        return ((ChessBoard)env).getColOf(owner.traget);
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(false, true, false, new List<string>() { SkillInf.TAG_DAMAGE,SkillInf.TAG_FIRE});

    }
    protected virtual Damage createDamage(Dictionary<string, object> skillArg,float multipe)
    {
        int atk = BaseDamageNum;
        List<string> tag = new List<string>() { Damage.TAG_FIRE, Damage.TAG_REMOTE };
        if ((bool)skillArg["critical"])
        {
            tag.Add("critical");
        }
        Damage damage = new Damage((int)(atk*multipe * (float)skillArg[Skill.ARG_MAG_MUL] + (int)skillArg[Skill.ARG_MAG_ADD]), Damage.KIND_MAGICAL, owner, tag);

        return damage;
    }
    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];
        float multipe = 1;
        BasicControler firstOne = (BasicControler)tragets[0];
        Quaternion rotate;
        if (firstOne.playerNo == 0)
        {
            rotate = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            rotate = Quaternion.Euler(0, 0, -90);
        }
        GameObject missile = Instantiate(objectList.main.prafebList[17], firstOne.transform.position, rotate);
        missile.transform.rotation = rotate;
        foreach (unitControler traget in tragets)
        {
            Damage d= createDamage(args, multipe);
            traget.takeDamage(d);
            multipe *= decay;
        }
        setTime(args);
    }

}
