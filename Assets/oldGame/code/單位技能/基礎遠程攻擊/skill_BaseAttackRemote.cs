using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_BaseAttackRemote : CDSkill {
    protected virtual Damage createDamage(Dictionary<string,object> skillArg)
    {
        int atk = owner.data.Now_Attack;
        List<string> tag = new List<string>() { Damage.TAG_ATTACK, Damage.TAG_CLOSE };
        if ((bool)skillArg["critical"])
        {
            tag.Add("critical");
        }
        Damage damage = new Damage((int)(atk * (float)skillArg[Skill.ARG_PHY_MUL]+(int)skillArg[Skill.ARG_PHY_ADD]), Damage.KIND_PHYSICAL, owner,tag);
        
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
            return 1;
        }
    }
    protected virtual int effNo_hit
    {
        get
        {
            return 3;
        }
    }
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0 && owner.traget != null&&owner.state.CanAttack;
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
    public virtual void misslieHit(missile m)
    {
        //Debug.Log("missile Hit被觸發");
        GameObject effobj= Instantiate(objectList.main.prafebList[effNo_hit], m.traget.gameObject.transform);
        effobj.transform.localPosition = Vector2.zero;
        //Debug.Log("物件名稱:" + effobj.gameObject.name);
    }
    public override void trigger(Dictionary<string, object> args)
    {
        //Debug.Log("角色名稱:"+gameObject.name);
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
                ActionForTraget(traget);
                //Debug.Log("冷卻時間:" + CoolDown);
                //Debug.Log("自身位置:" + transform.position + "相對位置:" + transform.TransformDirection(offset));
                Vector2 toTraget = nowTraget.transform.position - transform.position;
                float z_rotate = Vector2.Angle(Vector2.up, toTraget);

                GameObject mislobj = Instantiate(objectList.main.prafebList[missileNo], transform.TransformDirection(offset), transform.rotation);
                Vector2 relat_pos = Quaternion.Euler(0, 0, z_rotate) * offset;
                mislobj.transform.position = (Vector2)transform.position + relat_pos;
                mislobj.GetComponent<missile>().traget = ((BasicControler)traget).gameObject;
                if (effNo_hit >= 0)
                {
                    mislobj.GetComponent<missile>().on_missile_hited += misslieHit;
                }
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
