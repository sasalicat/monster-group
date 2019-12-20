using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBelt_v2 : SkillBelt {

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

    }
}
