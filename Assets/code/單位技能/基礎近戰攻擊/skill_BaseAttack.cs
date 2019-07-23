using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_BaseAttack : CDSkill {
    protected virtual Damage createDamage(Dictionary<string, object> skillArg)
    {
        int atk = owner.data.Now_Attack;
        List<string> tag = new List<string>() { Damage.TAG_ATTACK, Damage.TAG_CLOSE};
        if ((bool)skillArg["critical"])
        {
            tag.Add(Damage.TAG_CRITICAL);
        }
        Damage damage = new Damage((int)(atk * (float)skillArg[Skill.ARG_PHY_MUL] + (int)skillArg[Skill.ARG_PHY_ADD]), Damage.KIND_PHYSICAL, owner,tag);

        return damage;
    }
    public virtual  float animTime
    {
        get
        {
            return  0.25f;
        }
    }

    public virtual float stayTime
    {
        get
        {
            return 0.1f;
        }
    }
    protected readonly Vector2 offset = new Vector2(0.7f, 0.7f);
    public float anim_time = 0;
    public float stay_time = 0;
    protected int count = 0;
    protected Vector2 oriPos;
    public GameObject nowTraget=null;
    //protected bool triggerEff = false;
    public sp_effection effection;
    public  virtual int effNo{
        get
        {
            return 0;
        }
    } 
    public virtual int effNo_hit
    {
        get
        {
            return 2;
        }
    }
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0 && owner.traget != null && owner.state.CanAttack;
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
        this.information = new SkillInf(true,true,true,new List<string>() {SkillInf.TAG_DAMAGE});
        oriPos = transform.position;
        effection =GetComponent<sp_effection>();
    }
    public virtual void actionTo(unitControler[] tragets,Dictionary<string,object> skillArg)
    {
        tragets[0].takeDamage(createDamage(skillArg));
    }

    public override void trigger(Dictionary<string, object> args)
    {
        //Debug.Log("攻擊被觸發");
        //BasicControler traget = (BasicControler)args["tragets"];
        //Debug.Log("traget:"+traget);
        //Debug.Log("traget type:" + (args["tragets"].GetType()));
        unitControler[] tragets = (unitControler[])args["tragets"];
        if (!(bool)args["miss"])
        {

            //Debug.Log("製造傷害時傷害數值為:" + damage.num);
            actionTo(tragets,args);
            nowTraget = ((BasicControler)tragets[0]).gameObject;
            if (effection.rushMainStart(animTime,stayTime,nowTraget,Effection))
            {

            }
            else
            {
                Debug.Log("強制觸發Effection");
                Effection();
            }
            //anim_time = 0;
            //stay_time = 0;
            //
            //count = 0;
            //triggerEff = false;
            //Timer.main.logInTimer(Anim);
        }
        else
        {
            BasicControler traget = (BasicControler)tragets[0];
            NumberCreater.main.CreateMissing(traget.transform.position);
        }
        setTime();
    }
/*
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

        }
        else if (stay_time < stayTime)
        {
            if (!triggerEff)
            {
                if (effNo >= 0)
                {
                    GameObject neweff = Instantiate(objectList.main.prafebList[effNo], transform);
                    float Zangle = objectList.main.prafebList[effNo].transform.eulerAngles.z;
                    neweff.transform.localPosition = Vector2.zero;
                    Vector2 toTraget = (Vector2)transform.position - (Vector2)nowTraget.transform.position;
                    neweff.transform.up = toTraget;

                    //Debug.Log(gameObject.name+" neweff rotation:" + neweff.transform.eulerAngles);
                    Vector3 nowEuler = neweff.transform.eulerAngles;
                    //Debug.Log("nowEuler = " + nowEuler);
                    nowEuler.z += Zangle;
                    neweff.transform.eulerAngles = nowEuler;
                    //Debug.Log("neweff rotation +90:" + neweff.transform.eulerAngles);

                    sp_effection shaker = nowTraget.GetComponent<sp_effection>();
                    shaker.shakeStart(0.3f, 0.1f);
                    triggerEff = true;
                }
                if(effNo_hit >= 0)
                {
                    GameObject hitPrefab = objectList.main.prafebList[effNo_hit];
                    GameObject hiteff = Instantiate( hitPrefab,hitPrefab.transform.position,hitPrefab.transform.rotation, nowTraget.transform);
                    hiteff.transform.localPosition = hitPrefab.transform.position;
                }
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
    */
    public void Effection()
    {
        if (effNo >= 0)
        {
            GameObject neweff = Instantiate(objectList.main.prafebList[effNo], transform);
            float Zangle = objectList.main.prafebList[effNo].transform.eulerAngles.z;
            neweff.transform.localPosition = Vector2.zero;
            Vector2 toTraget = (Vector2)transform.position - (Vector2)nowTraget.transform.position;
            neweff.transform.up = toTraget;

            //Debug.Log(gameObject.name+" neweff rotation:" + neweff.transform.eulerAngles);
            Vector3 nowEuler = neweff.transform.eulerAngles;
            //Debug.Log("nowEuler = " + nowEuler);
            nowEuler.z += Zangle;
            neweff.transform.eulerAngles = nowEuler;
            //Debug.Log("neweff rotation +90:" + neweff.transform.eulerAngles);

            sp_effection shaker = nowTraget.GetComponent<sp_effection>();
            shaker.shakeStart(0.3f, 0.1f);
            
        }
        if (effNo_hit >= 0)
        {
            GameObject hitPrefab = objectList.main.prafebList[effNo_hit];
            GameObject hiteff = Instantiate(hitPrefab, hitPrefab.transform.position, hitPrefab.transform.rotation, nowTraget.transform);
            hiteff.transform.localPosition = hitPrefab.transform.position;
        }
    }
}
