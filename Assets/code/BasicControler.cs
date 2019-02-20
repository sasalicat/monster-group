using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicControler : MonoBehaviour,unitControler {
    public delegate void withDamage(Damage d);
    public delegate void forSkill(SkillInf skillInf, Dictionary<string, object> skillArgs);
    public delegate void forSkillTrageting(SkillInf skillInf, Dictionary<String, object> skillArgs, List<unitControler> tragets);
    public forSkill _beAppoint;
    public forSkillTrageting _befUseSkill;
    public withDamage _befTakeDamage;
    public withDamage _aftTakeDamage;
    public withDamage _aftCauseDamage;
    public unitData data;
    public unitState state;
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
    public virtual void useSkill(Skill skill)
    {
        if(((BasicControler)skill.Owner) != this)
        {
            return;
        }
        Dictionary<string, object> skillArg = new Dictionary<string, object>();

    }
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
