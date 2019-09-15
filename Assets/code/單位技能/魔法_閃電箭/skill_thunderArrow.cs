using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_thunderArrow : CDSkill {
    private readonly int BaseDamageNum = 5;

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
            return 1 * unitData.STAND_ATK_INTERVAL;
        }
    }


    public override unitControler[] findTraget(Environment env)
    {
        unitControler[] tragets = new unitControler[1];
        tragets[0] = owner.traget;
        return tragets;
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(false, true, false, new List<string>() { SkillInf.TAG_DAMAGE,SkillInf.TAG_THUNDER });

    }
    protected virtual Damage createDamage(Dictionary<string, object> skillArg)
    {
        int atk = BaseDamageNum;
        List<string> tag = new List<string>() { Damage.TAG_FIRE, Damage.TAG_REMOTE };
        if ((bool)skillArg["critical"])
        {
            tag.Add("critical");
        }
        Damage damage = new Damage((int)(atk  * (float)skillArg[Skill.ARG_MAG_MUL] + (int)skillArg[Skill.ARG_MAG_ADD]), Damage.KIND_MAGICAL, owner, tag);

        return damage;
    }
    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];



        foreach (BasicControler traget in tragets)
        {
            Damage d = createDamage(args);
            traget.takeDamage(d);
            GameObject missile = Instantiate(objectList.main.prafebList[23]);
            chain_stoker chain = missile.GetComponent<chain_stoker>();
            chain.tragets = new List<GameObject>();
            chain.tragets.Add(owner.gameObject);
            chain.tragets.Add(traget.gameObject);

            ((GameObject)Instantiate(objectList.main.prafebList[22], traget.transform)).transform.localPosition = Vector2.zero;
        }
        setTime(args);
    }


}
