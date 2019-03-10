using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_BaseAttack : CDSkill {

    public const float animTime = 0.25f;
    public const float stayTime = 0.1f;
    protected readonly Vector2 offset = new Vector2(0.7f, 0.7f);
    public float anim_time = 0;
    public float stay_time = 0;
    private int count = 0;
    protected Vector2 oriPos;
    public GameObject nowTraget=null;
    private bool triggerEff = false;
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
        oriPos = transform.position;
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
        anim_time = 0;
        stay_time = 0;
        nowTraget = ((BasicControler)tragets[0]).gameObject;
        count = 0;
        triggerEff = false;
        Timer.main.logInTimer(Anim);
    }

    public virtual void Anim(float time)
    {
        count++;
        anim_time += time;
        if (anim_time <= animTime)
        {
            float process = anim_time / animTime;
            process= EasingFunction.EaseInCubic(0, 1, process);
            Vector2 nowOffset = offset;
            Vector2 dist = nowTraget.transform.position - transform.position;
            if (Mathf.Abs(dist.x) < nowOffset.x)
            {
                nowOffset.x = Mathf.Abs(dist.x);
            }
            if (Mathf.Abs(dist.y) < nowOffset.y)
            {
                nowOffset.y = Mathf.Abs(dist.y);
            }
            //Debug.Log("count"+count+" tragetPos:" + (Vector2)nowTraget.transform.position + " oriPos:" + oriPos+" ans:" + ((Vector2)nowTraget.transform.position - oriPos) * process);
            Vector2 toTraget= ((Vector2)nowTraget.transform.position - oriPos);
            if(toTraget.x > 0)
            {
                toTraget.x -= nowOffset.x;
            }
            else
            {
                toTraget.x += nowOffset.x; 
            }
            if(toTraget.y > 0)
            {
                toTraget.y -= nowOffset.y;
            }
            else
            {
                toTraget.y += nowOffset.y;
            }
            transform.position = oriPos+ toTraget* process;
            /*if (stay_time >=  stayTime && !triggerEff)
            {
                GameObject neweff= Instantiate(objectList.main.prafebList[0], transform);
                neweff.transform.localPosition = Vector2.zero;
                toTraget = (Vector2)transform.position - (Vector2)nowTraget.transform.position;
                neweff.transform.right = toTraget;
                triggerEff = true;
            }*/
        }
        else if (stay_time < stayTime)
        {
            if (!triggerEff)
            {
                GameObject neweff = Instantiate(objectList.main.prafebList[0], transform);
                neweff.transform.localPosition = Vector2.zero;
                Vector2 toTraget = (Vector2)transform.position - (Vector2)nowTraget.transform.position;
                neweff.transform.right = toTraget;
                sp_effection shaker= nowTraget.GetComponent<sp_effection>();
                shaker.shakeStart(0.3f, 0.1f);
                triggerEff = true;
            }
            //Debug.Log("count" + count + "staying");
            stay_time += time;
        }
        else
        {
            transform.position = oriPos;
            Timer.main.loginOutTimer(Anim);
        }
    }
    
}
