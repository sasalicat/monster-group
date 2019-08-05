using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_bear_wildRoar : CDSkill
{
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
            return 3* owner.data.Now_Attack_Interval; ;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        unitControler[] tragets = new unitControler[1];
        List<BasicControler> firstTragets = new List<BasicControler>();
        List<BasicControler> enemy = new List<BasicControler>();
        foreach(BasicControler unit in ((ChessBoard)env).Units)
        {
            if (unit.playerNo != this.owner.playerNo) {
                enemy.Add(unit);
                if (unit.traget != owner)
                {
                    firstTragets.Add(unit);
                }
            }
        }
        if (firstTragets.Count != 0)
        {
            int index = Randomer.main.getInt() % firstTragets.Count;
            tragets[0] = firstTragets[index];
        }
        else if (enemy.Count != 0) 
        {
            int index = Randomer.main.getInt() % enemy.Count;
            tragets[0] = enemy[index];
        }
        else
        {
            tragets = new unitControler[0];
        }
        return tragets;
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(true, true, false, new List<string>() { SkillInf.TAG_DAMAGE });

    }
    private Damage createDamage(Dictionary<string, object> skillArg)
    {
        int num = 5;
        List<string> tag = new List<string>() { Damage.TAG_REMOTE, Damage.TAG_THUNDER };
        if ((bool)skillArg["critical"])
        {
            tag.Add("critical");
        }
        Damage damage = new Damage((int)(num * (float)skillArg[Skill.ARG_MAG_MUL] + (int)skillArg[Skill.ARG_MAG_ADD]), Damage.KIND_MAGICAL, owner, tag);

        return damage;
    }
    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];
        if (!(bool)args["miss"])
        {
            //BasicControler traget = (BasicControler)args["tragets"];
            //Debug.Log("traget:"+traget);
            //Debug.Log("traget type:" + (args["tragets"].GetType()));
            foreach (unitControler traget in tragets)
            {
                //Debug.Log("製造傷害時傷害數值為:" + damage.num);
                ((BasicControler)traget).traget = this.owner;

            }

        }
        else
        {
            BasicControler traget = (BasicControler)tragets[0];
            NumberCreater.main.CreateMissing(traget.transform.position);
        }
        Dictionary<string, object> barg = new Dictionary<string, object>();
        barg["creater"] = owner;
        barg["time"] = 5f;
        barg["num"] = 30;
        owner.addBuff("buff_heavySkin",barg);
        setTime();
    }
}
