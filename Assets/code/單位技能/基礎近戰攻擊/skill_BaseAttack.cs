using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_BaseAttack : CDSkill {

    public override bool canUse
    {
        get
        {
            return timeLeft <= 0 && owner.traget != null;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return 1;
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
        this.information = new SkillInf(true,true,true,new List<string>() {SkillInf.TAG_DAMAGE});
    }

    public override void trigger(Dictionary<string, object> args)
    {
        Debug.Log("攻擊被觸發");
        //BasicControler traget = (BasicControler)args["tragets"];
        //Debug.Log("traget:"+traget);
        //Debug.Log("traget type:" + (args["tragets"].GetType()));
        unitControler[] tragets =(unitControler[])args["tragets"];
        int atk = owner.data.Now_Attack;
        Damage damage = new Damage(atk,Damage.KIND_PHYSICAL,owner);
        //Debug.Log("製造傷害時傷害數值為:" + damage.num);
        Debug.Log("traget 為:" + ((BasicControler)tragets[0]).gameObject.name);
        tragets[0].takeDamage(damage);
        Debug.Log("冷卻時間:"+CoolDown);
        base.trigger(args);
    }
}
