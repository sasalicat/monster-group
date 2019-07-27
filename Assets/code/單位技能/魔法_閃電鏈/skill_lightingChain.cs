using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_lightingChain : CDSkill
{
    private int MAX_TRIGGER = 5;
    private int BASIC_NUM = 6;
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
            return 4* unitData.STAND_ATK_INTERVAL;
        }
    }
    private Damage createDamage(Dictionary<string, object> skillArg,int num)
    {
        List<string> tag = new List<string>() { Damage.TAG_ATTACK, Damage.TAG_CLOSE };
        if ((bool)skillArg["critical"])
        {
            tag.Add("critical");
        }
        Damage damage = new Damage((int)(num * (float)skillArg[Skill.ARG_MAG_MUL] + (int)skillArg[Skill.ARG_MAG_ADD]), Damage.KIND_MAGICAL, owner, tag);

        return damage;
    }
    public override unitControler[] findTraget(Environment env)
    {
        unitControler nowtraget = owner.traget;
        List<unitControler> tragets = new List<unitControler>();
        for(int i=0; i < MAX_TRIGGER; i++)
        {
            tragets.Add(nowtraget);
            unitControler[] canPick= ((ChessBoard)env).get3by3Of(nowtraget,false);
            if (canPick.Length == 0) {//找不到其他傳遞目標
                return tragets.ToArray();
            }
            int index = UnityEngine.Random.Range(0, canPick.Length);
            nowtraget = canPick[index];
        }
        return tragets.ToArray();
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(false, true, false, new List<string>() { SkillInf.TAG_DAMAGE });
    }

    public override void trigger(Dictionary<string, object> args)
    {
        List<GameObject> objs = new List<GameObject>();
        unitControler[] tragets = (unitControler[])args["tragets"];
        objs.Add(owner.gameObject);

        int num = BASIC_NUM;
        foreach (BasicControler traget in tragets)
        {
            objs.Add(traget.gameObject);
            if (num>0)
                traget.takeDamage(createDamage(args, num--));
        }
        GameObject chain = Instantiate(objectList.main.prafebList[18]);

        chain.GetComponent<chain_stoker>().tragets = objs;
        setTime();
    }
}
