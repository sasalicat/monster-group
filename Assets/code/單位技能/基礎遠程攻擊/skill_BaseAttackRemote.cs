using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_BaseAttackRemote : CDSkill {
    protected virtual Damage createDamage(Dictionary<string,object> skillArg)
    {
        int atk = owner.data.Now_Attack;
        List<string> tag = new List<string>() { Damage.TAG_ATTACK, Damage.TAG_CLOSE };
        Damage damage = new Damage((int)(atk * (float)skillArg[Skill.ARG_PHY_MUL]+(int)skillArg[Skill.ARG_PHY_ADD]), Damage.KIND_PHYSICAL, owner);
        
        return damage;
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
            return owner.data.Now_Attack_Interval;
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
        if (!(bool)args["miss"])
        {
            //BasicControler traget = (BasicControler)args["tragets"];
            //Debug.Log("traget:"+traget);
            //Debug.Log("traget type:" + (args["tragets"].GetType()));
            unitControler[] tragets = (unitControler[])args["tragets"];

            BasicControler nowTraget = (BasicControler)tragets[0];
   
            //Debug.Log("製造傷害時傷害數值為:" + damage.num);
            Debug.Log("traget 為:" + ((BasicControler)tragets[0]).gameObject.name);
            tragets[0].takeDamage(createDamage(args));
            //Debug.Log("冷卻時間:" + CoolDown);
            //Debug.Log("自身位置:" + transform.position + "相對位置:" + transform.TransformDirection(offset));
            Vector2 toTraget = nowTraget.transform.position - transform.position;
            float z_rotate = Vector2.Angle(Vector2.up, toTraget);

            GameObject mislobj = Instantiate(objectList.main.prafebList[missileNo], transform.TransformDirection(offset), transform.rotation);
            Vector2 relat_pos = Quaternion.Euler(0, 0, z_rotate) * offset;
            mislobj.transform.position = (Vector2)transform.position + relat_pos;
            mislobj.GetComponent<missile>().traget = ((BasicControler)tragets[0]).gameObject;
            
        }
        base.trigger(args);
    }


}
