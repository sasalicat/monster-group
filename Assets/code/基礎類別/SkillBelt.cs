using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBelt : MonoBehaviour,Callback4Unit {
    unitControler controler;
    public delegate void withFloat(float arg);
    protected withFloat _time_pass; 
    List<Skill> skills;
    List<Skill> activeSkills;
    List<skill_representation> repres;
    protected BasicDelegate.forSkill _be_appoint;
    public BasicDelegate.forSkill _BeAppoint
    {
        get
        {
            return _be_appoint;
        }

        set
        {
            _be_appoint = value;
        }
    }
    protected void beAppoint_cb(SkillInf skillInf, Dictionary<string, object> skillArgs)
    {
        if(_be_appoint!=null)
            _be_appoint(skillInf, skillArgs);
    }

    protected BasicDelegate.forSkillTrageting _bef_use_skill;
    public BasicDelegate.forSkillTrageting _BefUseSkill
    {
        get
        {
            return _bef_use_skill;
        }

        set
        {
            _bef_use_skill = value;
        }
    }
    protected void befUseSkill_cb(SkillInf skillInf, Dictionary<string, object> skillArgs, unitControler[] tragets)
    {
        if(_bef_use_skill !=null)
            _bef_use_skill( skillInf,  skillArgs,tragets);
    }

    protected BasicDelegate.withDamage _bef_take_damage;
    public BasicDelegate.withDamage _BefTakeDamage
    {
        get
        {
            return _bef_take_damage;
        }

        set
        {
            _bef_take_damage = value;
        }
    }
    protected void befTakeDamage_cb(Damage d)
    {
        if(_bef_take_damage!=null)
            _bef_take_damage(d);
    }

    protected BasicDelegate.withDamage _aft_take_damage;
    public BasicDelegate.withDamage _AftTakeDamage
    {
        get
        {
            return _aft_take_damage;
        }

        set
        {
            _aft_take_damage = value;
        }
    }
    protected void aftTakeDamage_cb(Damage d)
    {
        if(_aft_cause_damage!=null)
            _aft_take_damage(d);
    }

    BasicDelegate.withDamage _aft_cause_damage;
    public BasicDelegate.withDamage _AftCauseDamage
    {
        get
        {
            return _aft_take_damage;
        }

        set
        {
            _aft_take_damage = value;
        }
    }

    public BasicDelegate.withInt _onHpChange
    {
        get
        {
            return ((BasicControler)controler).data._onLifeChange;
        }

        set
        {
            ((BasicControler)controler).data._onLifeChange = value;
        }
    }
    protected void aftUseSkill_cb(SkillInf skillInf, Dictionary<string, object> skillArgs, unitControler[] tragets)
    {
        if (_aft_use_skill != null)
            _aft_use_skill(skillInf, skillArgs, tragets);
    }
    BasicDelegate.forSkillTrageting _aft_use_skill;  
    public BasicDelegate.forSkillTrageting _AftUseSkill
    {
        get
        {
            return _aft_use_skill;
        }

        set
        {
            _aft_use_skill = value;
        }
    }

    protected void aftCauseDamage_cb(Damage d)
    {
        if(_aft_cause_damage !=null)
            _aft_take_damage(d);
    }

    public virtual void addSkillBy(string represName)
    {
        object newrepres= System.Activator.CreateInstance(System.Type.GetType(represName));
        string skillName = ((skill_representation)newrepres).ScriptName;
        Skill newone=(Skill)gameObject.AddComponent(System.Type.GetType(skillName));
        Debug.Log("skillname:" + skillName+" type:"+ System.Type.GetType(skillName));
        //Debug.Log("represName name:" + represName + " parent:"+ newone.GetComponentInParent(System.Type.GetType("CDSkill")));
        if(System.Type.GetType(skillName).IsSubclassOf(System.Type.GetType("CDSkill")))
        //if (newone.GetComponentInParent(System.Type.GetType("CDSkill")) != null)//如果是CD型技能
        {
            _time_pass += ((CDSkill)newone).timePass;
        }
        newone.onInit(controler,this);
        if (newone.information.activeSkill)//如果是
        {
            activeSkills.Add(newone);
        }
        skills.Add(newone);
    }
    public virtual void updateSkill(float time,Environment env)
    {
        //Debug.Log("updateSkill time:" + time);
        if(_time_pass !=null)
            _time_pass(time);
        foreach(CDSkill act in activeSkills)
        {
            //Debug.Log("act canUse:" + act.canUse);
            if (act.canUse)
            {
                act.arouse(env);
            }
        }
    }

    public virtual void init(unitControler controler,List<int> skillNos)
    {
        this.controler = controler;
        ((BasicControler)controler)._beAppoint += beAppoint_cb;
        ((BasicControler)controler)._befUseSkill += befUseSkill_cb;
        ((BasicControler)controler)._aftUseSkill += aftUseSkill_cb;
        ((BasicControler)controler)._befTakeDamage += befTakeDamage_cb;
        ((BasicControler)controler)._aftTakeDamage += aftTakeDamage_cb;
        ((BasicControler)controler)._aftCauseDamage += aftCauseDamage_cb;
        skills =new List<Skill>();
        activeSkills = new List<Skill>();
        repres = new List<skill_representation>();
        foreach(int no in skillNos)
        {
            string respName = SkillList.main.representation[no];
            Debug.Log("no:" + no + "respName:" + respName);
            addSkillBy(respName);
        }
        //Timer.main.logInTimer(interval);
    }
}
