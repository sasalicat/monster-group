using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_skyPunishment : CDSkill {
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
            return 6 * owner.data.Now_Attack_Interval; ;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        List<BasicControler> Subs = new List<BasicControler>();
        foreach (BasicControler unit in ((ChessBoard)env).units)
        {
            if (unit.playerNo != owner.playerNo)
            {
                Subs.Add(unit);
            }
        }
        unitControler[] tragets ;
        if (Subs.Count < 3)
        {
            tragets = new unitControler[Subs.Count];
        }
        else
        {
            tragets = new unitControler[3];
        }
        for (int i = 0; i < tragets.Length; i++)
        {
            int index = Randomer.main.getInt() % Subs.Count;
            tragets[i] = Subs[index];
            Subs.RemoveAt(index);
        }

        return tragets;
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(true, true, false, new List<string>() { SkillInf.TAG_DAMAGE,SkillInf.TAG_THUNDER });

    }
    private Damage createDamage(Dictionary<string, object> skillArg)
    {
        int base_num = 5;
        List<string> tag = new List<string>() { Damage.TAG_THUNDER, Damage.TAG_REMOTE };
        if ((bool)skillArg["critical"])
        {
            tag.Add("critical");
        }
        base_num += Randomer.main.getInt() % 11;
        Damage damage = new Damage((int)(base_num * (float)skillArg[Skill.ARG_MAG_MUL] + (int)skillArg[Skill.ARG_MAG_ADD]), Damage.KIND_MAGICAL, owner, tag);

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

                BasicControler nowTraget = (BasicControler)traget;

                //Debug.Log("製造傷害時傷害數值為:" + damage.num);
                Debug.Log("traget 為:" + ((BasicControler)traget).gameObject.name);
                traget.takeDamage(createDamage(args));
                //Debug.Log("冷卻時間:" + CoolDown);
                //Debug.Log("自身位置:" + transform.position + "相對位置:" + transform.TransformDirection(offset));
                GameObject effobj = Instantiate(objectList.main.prafebList[19], nowTraget.transform);
                effobj.transform.localPosition = Vector2.zero;
            }

        }
        else
        {
            BasicControler traget = (BasicControler)tragets[0];
            NumberCreater.main.CreateMissing(traget.transform.position);
        }
        setTime(args);
    }
    

}
