﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicControler : MonoBehaviour,unitControler {
    
    public BasicDelegate.forSkill _beAppoint;
    public BasicDelegate.forSkillTrageting _befUseSkill;
    public BasicDelegate.withDamage _befTakeDamage;
    public BasicDelegate.withDamage _aftTakeDamage;
    public BasicDelegate.withDamage _aftCauseDamage;
    public HpBar hpbar = null;
    protected float recover_timeLeft = unitData.STAND_RECOVER_INTERVAL;
    public unitData data;
    public unitState state;
    public SkillBelt skillBelt;
    public AI ai;
    public unitControler traget = null;
    public Environment env;
    public int playerNo = -1;

    public virtual Dictionary<string,object> createSkillArg(unitData data)
    {
        Dictionary<string, object> arg = new Dictionary<string, object>();
        arg["miss"] = false;
        arg["dice"] = Randomer.main.getInt();
        arg["phy_damage_multiple"] = data.Now_Mag_Multiple;
        arg["phy_damage_addition"] = 0;
        arg["mag_damage_multiple"] = 1f;
        arg["mag_damage_addition"] = 0;
        arg["healing_multiple"] = 1f;
        arg["healing_addition"] = 0;
        arg["control_multiple"] = 1f;
        arg["control_addition"] = 0;

        return arg;
    }
    public virtual void addBuff(string buffName)
    {
        gameObject.AddComponent(Type.GetType(buffName));
    }

    public virtual void takeDamage(Damage damage)
    {
        _befTakeDamage(damage);
        if (damage.vaild)
        {
            if (damage.kind == Damage.KIND_PHYSICAL && !state.ImmunePhysics)
            {
                //Debug.Log("計算傷害時Physical_Reduce_Multiple為:" + data.Physical_Reduce_Multiple);
                int hurt = (int)(data.Physical_Reduce_Multiple * damage.num);
                //Debug.Log("計算傷害時hurt為:"+hurt);
                //Debug.Log("計算傷害時Now_Life為:" + data.Now_Life);
                data.Now_Life -= hurt;
                //Debug.Log("計算結束");
                _aftTakeDamage(damage);
                createDamageNum(damage);
                BasicControler from = (BasicControler)damage.creater;
                damage.creater = this;//將creater改成自己來告訴傷害的造成者傷害目標是誰
                if (damage.creater != null)
                {
                    from._aftCauseDamage(damage);
                }
            }
            else if (damage.kind == Damage.KIND_MAGICAL && !state.ImmuneMagic)
            {
                int hurt = (int)(data.Magic_Reduce_Multiple * damage.num);
                data.Now_Life -= hurt;
                _aftTakeDamage(damage);
                createDamageNum(damage);
                BasicControler from = (BasicControler)damage.creater;
                damage.creater = this;//將creater改成自己來告訴傷害的造成者傷害目標是誰
                if (damage.creater != null)
                {
                    from._aftCauseDamage(damage);
                }
            }
        }

    }
    public virtual void useSkill(Skill skill,unitControler[] tragets)
    {
        if(((BasicControler)skill.Owner) != this)
        {
            return;
        }
        Dictionary<string, object> skillArg = createSkillArg(data);
        skillArg["tragets"] = tragets;
        foreach (unitControler traget in tragets)
        {
            ((BasicControler)traget)._beAppoint(skill.information, skillArg);//被指定
        }
        _befUseSkill(skill.information,skillArg,tragets);
        ((CDSkill)skill).trigger(skillArg);
    }

    public void action(float time)
    {
        //Debug.Log("角色 action");
        skillBelt.updateSkill(time,env);
        ai.update(this, env);
        recover_timeLeft -= time;
        if (recover_timeLeft <= 0)
        {
            data.Now_Life += data.Now_Life_Recover;
            Debug.Log(gameObject.name + " 恢復:" + data.Now_Life_Recover);
            recover_timeLeft = unitData.STAND_RECOVER_INTERVAL;
        }
    }
    public void hpbarCallBack(int nowHp)
    {
        //Debug.Log("now_max_life為:" + data.Now_Max_Life);
        hpbar.Percentage = (float)nowHp / (float)data.Now_Max_Life;
       
    }
    public void init(AI ai,Environment env,unitData data,HpBar hpbar)
    {
        this.ai = ai;
        this.env = env;
        this.data = data;
        this.state = new unitState();
        this.hpbar = hpbar;
        this.data._onLifeChange += hpbarCallBack;
    }
    public void createDamageNum(Damage damage)
    {
        NumberCreater.main.CreateFloatingNumber(damage.num,transform.position,0);
    }
}
