using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBelt_v2 : SkillBelt,Callback4Unit_v2{
    //新callback
    public void crit_callback(Damage d)
    {
        if(_crit_cb!=null)
            _crit_cb(d);
    }
    BasicDelegate.withDamage _crit_cb;
    public BasicDelegate.withDamage _aftCrit
    {
        get
        {
            return _crit_cb;
        }

        set
        {
            _crit_cb = value;
        }
    }
    public void block_callback(Damage d)
    {
        if(_block_cb!=null)
            _block_cb(d);
    }
    BasicDelegate.withDamage _block_cb;
    public BasicDelegate.withDamage _aftBlock
    {
        get
        {
            return _block_cb;
        }
        set
        {
            _block_cb = value;
        }
    }


    public void dodge_callback(SkillInf inf,Dictionary<string,object> dict)
    {
        if(_dodge_cb!=null)
            _dodge_cb(inf,dict);
    }
    BasicDelegate.forSkill _dodge_cb;

    public BasicDelegate.forSkill _aftDodge
    {
        get
        {
            return _dodge_cb;
        }

        set
        {
            _dodge_cb = value;
        }
    }
    //---------------------------------------------------------------
    public virtual Skill addSkillDirectBy(string scriptName,modifier[] mods)
    {
        dynamicSkill newone = (dynamicSkill)gameObject.AddComponent(System.Type.GetType(scriptName));
        //Debug.Log("skillname:" + scriptName + " type:" + System.Type.GetType(scriptName));
        //Debug.Log("represName name:" + represName + " parent:"+ newone.GetComponentInParent(System.Type.GetType("CDSkill")));
        if (System.Type.GetType(scriptName).IsSubclassOf(System.Type.GetType("CDSkill")))
        //if (newone.GetComponentInParent(System.Type.GetType("CDSkill")) != null)//如果是CD型技能
        {
            _time_pass += ((CDSkill)newone).timePass;
        }
        newone.onInit(controler, this,mods);
        if (newone.information.activeSkill)//如果是
        {
            activeSkills.Add(newone);
        }
        skills.Add(newone);
        return newone;
    }
    public override void addSkillBy(string represName)
    {
        object newrepres = System.Activator.CreateInstance(System.Type.GetType(represName));
        //string key = ((skill_resource)newrepres).dictKey;
        string skillName = ((skill_resource)newrepres).ScriptName;
        ((skill_resource)newrepres).init(((comboControler)controler).data);
        dynamicSkill newskill=(dynamicSkill)addSkillDirectBy(skillName, ((skill_resource)newrepres).mods);
        //newskill.setResources(((skill_resource)newrepres).resource);
    }
    public override void init(unitControler controler, List<int> skillNos)
    {
        base.init(controler, skillNos);
        ((comboControler)controler).counterSkill = skills[0];
        ((comboControler)controler)._aftCrit += crit_callback;
        ((comboControler)controler)._aftBlock += block_callback;
        ((comboControler)controler)._aftDodge += dodge_callback;
    }
}
