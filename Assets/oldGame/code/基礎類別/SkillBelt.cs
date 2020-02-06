using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBelt : MonoBehaviour,Callback4Unit {
    protected unitControler controler;
    public delegate void withFloat(float arg);
    protected withFloat _time_pass; 
    protected List<Skill> skills;
    protected List<Skill> activeSkills;
    protected List<skill_representation> repres;
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

    protected BasicDelegate.forRefSkillTrageting _bef_use_skill;
    public BasicDelegate.forRefSkillTrageting _BefUseSkill
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
    protected void befUseSkill_cb(SkillInf skillInf, Dictionary<string, object> skillArgs,ref unitControler[] tragets)
    {
        if(_bef_use_skill !=null)
            _bef_use_skill( skillInf,  skillArgs,ref tragets);
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
        if(_aft_take_damage != null)
            _aft_take_damage(d);
    }
    BasicDelegate.withDamage befCauseDamage;
    public BasicDelegate.withDamage _befCauseDamage
    {
        get
        {
            return befCauseDamage;
        }

        set
        {
            befCauseDamage = value;
        }
    }
    void befCauseDamage_cb(Damage damage)
    {
        if (befCauseDamage != null)
            befCauseDamage(damage);
    }
    BasicDelegate.withDamage _aft_cause_damage;
    public BasicDelegate.withDamage _AftCauseDamage
    {
        get
        {
            return _aft_cause_damage;
        }

        set
        {
            _aft_cause_damage = value;
        }
    }
    BasicDelegate.withInt _on_life_change;
    protected void onLifeChange_cb(int hp)
    {
        if(_on_life_change!=null)
            _on_life_change(hp);
    }
    public BasicDelegate.withInt _onHpChange
    {
        get
        {
            return _on_life_change;
        }

        set
        {
            _on_life_change = value;
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
    BasicDelegate.withBuffAndControler _on_get_buff;
    public BasicDelegate.withBuffAndControler _onGetBuff
    {
        get
        {
            return _on_get_buff;
        }

        set
        {
            _on_get_buff = value;
        }
    }
    protected void onGetBuff_cb(Buff buff,unitControler creater)
    {
        if (_on_get_buff != null) {
            _on_get_buff(buff, creater);
        }
    }
    BasicDelegate.withBuffAndControler _on_create_buff;
    public BasicDelegate.withBuffAndControler _onCreateBuff
    {
        get
        {
            return _on_create_buff;
        }

        set
        {
            _on_create_buff = value;
        }
    }
    public List<Skill> ActiveSkills
    {
        get {
            return activeSkills;
        }
    }
    protected void onCreateBuff_cb(Buff buff,unitControler traget)
    {
        if (_on_create_buff != null)
            _on_create_buff(buff, traget);
    }
    protected void aftCauseDamage_cb(Damage d)
    {
        if(_aft_cause_damage !=null)
            _aft_cause_damage(d);
    }

    public virtual void addSkillBy(string represName)
    {
        Debug.Log("represName:" + represName);
        object newrepres= System.Activator.CreateInstance(System.Type.GetType(represName));
        string skillName = ((skill_representation)newrepres).ScriptName;
        addSkillDirectBy(skillName);
        /*Skill newone=(Skill)gameObject.AddComponent(System.Type.GetType(skillName));
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
        skills.Add(newone);*/
    }
    public virtual Skill addSkillDirectBy(string scriptName)
    {
        Skill newone = (Skill)gameObject.AddComponent(System.Type.GetType(scriptName));
        //Debug.Log("skillname:" + scriptName + " type:" + System.Type.GetType(scriptName));
        //Debug.Log("represName name:" + represName + " parent:"+ newone.GetComponentInParent(System.Type.GetType("CDSkill")));
        if (System.Type.GetType(scriptName).IsSubclassOf(System.Type.GetType("CDSkill")))
        //if (newone.GetComponentInParent(System.Type.GetType("CDSkill")) != null)//如果是CD型技能
        {
            _time_pass += ((CDSkill)newone).timePass;
        }
        newone.onInit(controler, this);
        if (newone.information.activeSkill)//如果是
        {
            activeSkills.Add(newone);
        }
        skills.Add(newone);
        return newone;
    }
    public virtual void aftAllUnitInit(Manager manager)
    {
        foreach(Skill skill in skills)
        {
            skill.onEnvReady(manager);
        }
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
        ((BasicControler)controler)._befCauseDamage += befCauseDamage_cb;
        ((BasicControler)controler)._aftCauseDamage += aftCauseDamage_cb;
        ((BasicControler)controler).data._onLifeChange += onLifeChange_cb;
        ((BasicControler)controler)._onGetBuff += onGetBuff_cb;
        ((BasicControler)controler)._onCreateBuff += onCreateBuff_cb;
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
