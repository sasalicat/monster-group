using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_burn : CDSkill
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
            return 4*owner.data.Now_Attack_Interval; ;
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
    private  Damage createDamage(Dictionary<string,object> skillArg)
    {
        int num = 5;
        List<string> tag = new List<string>() { Damage.TAG_ATTACK, Damage.TAG_CLOSE };
        if ((bool)skillArg["critical"])
        {
            tag.Add("critical");
        }
        Damage damage = new Damage((int)(num * (float)skillArg[Skill.ARG_MAG_MUL]+(int)skillArg[Skill.ARG_MAG_ADD]), Damage.KIND_MAGICAL, owner,tag);
        
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
                GameObject effobj= Instantiate(objectList.main.prafebList[13], nowTraget.transform);
                effobj.transform.localPosition = Vector2.zero;
                Dictionary<string,object> buffArgs = new Dictionary<string,object>();
                buffArgs["time"] = 3.0f;
                buffArgs["layer"] =1;
                buffArgs["creater"] =owner;
                nowTraget.addBuff("buff_burn",buffArgs);
            }
            
        }
        else
        {
            BasicControler traget = (BasicControler)tragets[0];
            NumberCreater.main.CreateMissing(traget.transform.position);
        }
        setTime();
    }
    
}
