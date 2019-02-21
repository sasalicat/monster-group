using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBelt : MonoBehaviour {
    unitControler controler;
    public delegate void withFloat(float arg);
    protected withFloat _time_pass; 
    List<Skill> skills;
    List<Skill> activeSkills;
    public virtual void addSkillBy(string skillName)
    {
        Skill newone=(Skill)gameObject.AddComponent(System.Type.GetType(skillName));
        if (newone.GetComponentInParent(System.Type.GetType("CDSkill")) != null)//如果是CD型技能
        {
            _time_pass += ((CDSkill)newone).timePass;
        }
        newone.onInit(controler);
        if (newone.information.activeSkill)//如果是
        {
            activeSkills.Add(newone);
        }
        skills.Add(newone);
    }
    public virtual void updateSkill(float time,Environment env)
    {
        _time_pass(time);
        foreach(Skill act in activeSkills)
        {
            if (act.canUse)
            {
                act.arouse(env);
            }
        }
    }

    public virtual void init(unitControler controler)
    {
        this.controler = controler;
        //Timer.main.logInTimer(interval);
    }
}
