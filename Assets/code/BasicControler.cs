using System;
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

    public unitData data;
    public unitState state;
    public SkillBelt skillBelt;
    public AI ai;
    public unitControler traget = null;
    public Environment env;
    public int playerNo = -1;

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
                int hurt = (int)(data.Physical_Reduce_Multiple * damage.num);
                data.Now_Life -= hurt;
                _aftTakeDamage(damage);
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
        Dictionary<string, object> skillArg = new Dictionary<string, object>();
        foreach(unitControler traget in tragets)
        {
            ((BasicControler)traget)._beAppoint(skill.information, skillArg);//被指定
        }
        _befUseSkill(skill.information,skillArg,tragets);
        skill.trigger(skillArg);
    }

    public void action(float time)
    {
        skillBelt.updateSkill(time,env);
        ai.update(this, env);
    }
    public void hpbarCallBack(int nowHp)
    {
        hpbar.Percentage = (float)nowHp / (float)data.Now_Max_Life;
    }
    public void init(AI ai,Environment env,unitData data)
    {
        this.ai = ai;
        this.env = env;
        this.data = data;

    }
}
