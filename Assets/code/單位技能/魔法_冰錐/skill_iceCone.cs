using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_iceCone : CDSkill {
    protected virtual Damage createDamage(Dictionary<string, object> skillArg,bool crit)
    {
        int num = 10;
        List<string> tag = new List<string>() { Damage.TAG_ICE, Damage.TAG_REMOTE };
        if (crit)
        {
            num = 23;
            tag.Add("critical");
        }
        if ((bool)skillArg["critical"])
        {
            tag.Add("critical");
        }
        Damage damage = new Damage((int)(num * (float)skillArg[Skill.ARG_MAG_MUL] + (int)skillArg[Skill.ARG_MAG_ADD]), Damage.KIND_MAGICAL, owner, tag);

        return damage;
    }
    protected virtual void ActionForTraget(unitControler traget)
    {

    }
    protected virtual Vector2 offset
    {
        get
        {
            return new Vector2(0, 1);
        }
    }
    protected virtual int missileNo
    {
        get
        {
            return 28;
        }
    }
    protected virtual int effNo_hit
    {
        get
        {
            return 25;
        }
    }
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
            return owner.data.Now_Attack_Interval*3;
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
        this.information = new SkillInf(true, true, false, new List<string>() { SkillInf.TAG_DAMAGE,SkillInf.TAG_ICE});

    }
    public override void trigger(Dictionary<string, object> args)
    {
        //Debug.Log("攻擊被觸發");
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
                bool haveBuff = (((BasicControler)traget).GetComponent<buff_chill>() != null);//如果目標有寒冷狀態,則暴擊
                traget.takeDamage(createDamage(args,haveBuff));
                ActionForTraget(traget);
                //Debug.Log("冷卻時間:" + CoolDown);
                //Debug.Log("自身位置:" + transform.position + "相對位置:" + transform.TransformDirection(offset));

                GameObject mislobj = Instantiate(objectList.main.prafebList[missileNo],((BasicControler)traget).transform.position, transform.rotation);
                GameObject effobj = Instantiate(objectList.main.prafebList[effNo_hit],((BasicControler)traget).gameObject.transform);
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
