using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicControler : MonoBehaviour,unitControler {
    
    public BasicDelegate.forSkill _beAppoint;
    public BasicDelegate.forRefSkillTrageting _befUseSkill;
    public BasicDelegate.forSkillTrageting _aftUseSkill;
    public BasicDelegate.withDamage _befTakeDamage;
    public BasicDelegate.withDamage _aftTakeDamage;
    public BasicDelegate.withDamage _aftCauseDamage;
    public BasicDelegate.withHealMsg _befHealing;
    public BasicDelegate.withHealMsg _aftHealing;
    public BasicDelegate.withGameObject _onDeath;
    public BasicDelegate.withBuffAndControler _onCreateBuff;
    public BasicDelegate.withBuffAndControler _onGetBuff;
    public HpBar hpbar = null;
    protected float recover_timeLeft = unitData.STAND_RECOVER_INTERVAL;
    public unitData data;
    public unitState state;
    public SkillBelt skillBelt;
    public AI ai;
    public unitControler traget = null;
    public Environment env;
    public int playerNo = -1;
    public List<Buff> buffList = new List<Buff>();
    protected List<Buff> failed = new List<Buff>();
    void buffFail_callback(Buff b) {
        failed.Add(b);
    }
    public void onUnitDeath()
    {
        _onDeath(gameObject);
    }
    public virtual Dictionary<string,object> createSkillArg(unitData data)
    {
        Dictionary<string, object> arg = new Dictionary<string, object>();
        arg["miss"] = false;
        arg["bonus"] = false;//因為技能效果所而額外觸發的技能
        arg["dice"] = Randomer.main.getInt();
        arg["critical"] = false;
         arg["phy_damage_multiple"] = 1f;
        arg["phy_damage_addition"] = 0;
        arg["mag_damage_multiple"] = data.Now_Mag_Multiple;
        arg["mag_damage_addition"] = 0;
        arg["healing_multiple"] = data.Now_Mag_Multiple;
        arg["healing_addition"] = 0;
        arg["control_multiple"] = 1f;
        arg["control_addition"] = 0;
        return arg;
    }
    public virtual void addBuff(string buffName)
    {
        Debug.LogWarning("addBuff中 buffname:" + buffName);
        Buff buff= (Buff)gameObject.AddComponent(Type.GetType(buffName));
        Buff[] before = (Buff[])GetComponents(Type.GetType(buffName));
        buff.onfail += buffFail_callback;
        buff.onInit(this, before, null);
        _onGetBuff(buff, null);
        buffList.Add(buff);
    }
    public virtual void addBuff(string buffName,Dictionary<string,object> dict)
    {
        BasicControler creater = null;
        if (dict.ContainsKey("creater"))
        {
            creater = (BasicControler)dict["creater"];
        }
        //Debug.Log("buffname:"+buffName+","+GetComponents(Type.GetType(buffName)));
        Component[] comps = GetComponents(Type.GetType(buffName));
        Buff buff = (Buff)gameObject.AddComponent(Type.GetType(buffName));
        Buff[] before = new Buff[comps.Length];
        for(int i = 0; i < comps.Length; i++)
        {
            before[i] = (Buff)comps[i];
        }
        buff.onfail += buffFail_callback;
        if (buff.onInit(this, before, dict))
        {
            buffList.Add(buff);
            if (creater != null && creater._onCreateBuff!=null) {
                creater._onCreateBuff(buff,this);
            }
            if(_onGetBuff!=null)
                _onGetBuff(buff, creater);
        }
        else
        {
            Destroy(buff);
        }
    }
    public virtual void heal(int num, unitControler creater)
    {
        HealMsg msg = new HealMsg(num, creater);
        if (_befHealing != null)
        {
            _befHealing(msg);
        }
        data.Now_Life += num;
        createHealNum(msg);
        if (_aftHealing != null)
        {
            _aftHealing(msg);
        }
    }
    public virtual void takeDamage(Damage damage)
    {
        _befTakeDamage(damage);
        if (damage.vaild&&!data.Dead)
        {
            if (damage.kind == Damage.KIND_PHYSICAL && !state.ImmunePhysics)
            {
                //Debug.Log("計算傷害時Physical_Reduce_Multiple為:" + data.Physical_Reduce_Multiple);
                int hurt = (int)(data.Physical_Reduce_Multiple * (float)damage.num);
                //Debug.Log("計算傷害時hurt為:"+hurt);
                //Debug.Log("計算傷害時Now_Life為:" + data.Now_Life);
                data.Now_Life -= hurt;
                //Debug.Log("計算結束");
                damage.num = hurt;
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
            else if (damage.kind == Damage.KIND_REAL) {
                data.Now_Life -= damage.num;
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
        //Debug.Log("skill:" + skill.name);
        if(((BasicControler)skill.Owner) != this)
        {
            return;
        }
        Dictionary<string, object> skillArg = createSkillArg(data);

        foreach (unitControler traget in tragets)
        {
            ((BasicControler)traget)._beAppoint(skill.information, skillArg);//被指定
        }
        _befUseSkill(skill.information,skillArg,ref tragets);
        //Debug.LogWarning("在useSkill后tragets Count:"+tragets.Length);
        skillArg["tragets"] = tragets;
        ((CDSkill)skill).trigger(skillArg);
        _aftUseSkill(skill.information, skillArg, tragets);
    }
    public virtual void useSkill(Skill skill, unitControler[] tragets,Dictionary<string,object> arg)
    {
        if (((BasicControler)skill.Owner) != this)
        {
            return;
        }
        arg["tragets"] = tragets;
        foreach (unitControler traget in tragets)
        {
            ((BasicControler)traget)._beAppoint(skill.information, arg);//被指定
        }
        _befUseSkill(skill.information, arg,ref tragets);
        ((CDSkill)skill).trigger(arg);
        _aftUseSkill(skill.information, arg, tragets);
    }
    public void action(float time)
    {
        //Debug.Log("角色 action");
        //ai更新
        ai.update(this, env);
        //技能使用
        skillBelt.updateSkill(time,env);

        
        //處理buff
        foreach(Buff buff in buffList)
        {
            if (!failed.Contains(buff))
            {
                buff.onIntarvel(this, time);
            }
        }
        for(int i = 0; i < failed.Count; i++)
        {
            buffList.Remove(failed[i]);
        }
        failed.Clear();
        //處理血量恢復
        recover_timeLeft -= time;
        if (recover_timeLeft <= 0)
        {
            heal(data.Now_Life_Recover,this);
            Debug.Log(gameObject.name + " 恢復:" + data.Now_Life_Recover);
            recover_timeLeft = unitData.STAND_RECOVER_INTERVAL;
        }
    }
    public void hpbarCallBack(int nowHp)
    {
        //Debug.Log("now_max_life為:" + data.Now_Max_Life);
        //Debug.Log("角色:" + gameObject.name);
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
        this.data._onDeath = onUnitDeath;
    }
    public void createHealNum(HealMsg msg)
    {
        NumberCreater.main.CreateFloatingNumber(msg.num, transform.position, 2);
    }
    public void createDamageNum(Damage damage)
    {
        if (!damage.tag.Contains("critical"))
            NumberCreater.main.CreateFloatingNumber(damage.num, transform.position, 0);
        else
            NumberCreater.main.CreateFloatingNumber(damage.num, transform.position, 1);
    }
}
