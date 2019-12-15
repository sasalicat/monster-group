using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBelt_v2 : SkillBelt {
    
    public override void addSkillBy(string represName)
    {
        object newrepres = System.Activator.CreateInstance(System.Type.GetType(represName));
        //string key = ((skill_resource)newrepres).dictKey;
        string skillName = ((skill_resource)newrepres).ScriptName;
        ((skill_resource)newrepres).init(((comboControler)controler).data);
        dynamicSkill newskill=(dynamicSkill)addSkillDirectBy(skillName);
        //newskill.setResources(((skill_resource)newrepres).resource);
    }
    public override void init(unitControler controler, List<int> skillNos)
    {
        base.init(controler, skillNos);
        ((comboControler)controler).counterSkill = skills[0];

    }
}
