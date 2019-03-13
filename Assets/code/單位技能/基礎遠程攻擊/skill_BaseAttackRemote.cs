using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_BaseAttackRemote : CDSkill {
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
            return 1;
        }
    }
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
        this.information = new SkillInf(true, true, true, new List<string>() { SkillInf.TAG_DAMAGE });

    }

    public override void trigger(Dictionary<string, object> args)
    {
        Debug.Log("攻擊被觸發");
        //BasicControler traget = (BasicControler)args["tragets"];
        //Debug.Log("traget:"+traget);
        //Debug.Log("traget type:" + (args["tragets"].GetType()));
        unitControler[] tragets = (unitControler[])args["tragets"];
        int atk = owner.data.Now_Attack;
        BasicControler nowTraget = (BasicControler)tragets[0];
        Damage damage = new Damage(atk, Damage.KIND_PHYSICAL, owner);
        //Debug.Log("製造傷害時傷害數值為:" + damage.num);
        Debug.Log("traget 為:" + ((BasicControler)tragets[0]).gameObject.name);
        tragets[0].takeDamage(damage);
        //Debug.Log("冷卻時間:" + CoolDown);
        //Debug.Log("自身位置:" + transform.position + "相對位置:" + transform.TransformDirection(offset));
        Vector2 toTraget = nowTraget.transform.position - transform.position;
        float z_rotate = Vector2.Angle(Vector2.up, toTraget);

        GameObject mislobj = Instantiate(objectList.main.prafebList[missileNo],transform.TransformDirection(offset),transform.rotation);
        Vector2 relat_pos= Quaternion.Euler(0, 0, z_rotate)* offset;
        mislobj.transform.position = (Vector2)transform.position + relat_pos;
        mislobj.GetComponent<missile>().traget = ((BasicControler)tragets[0]).gameObject;
        base.trigger(args);
    }


}
