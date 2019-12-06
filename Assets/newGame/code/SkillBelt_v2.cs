using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBelt_v2 : SkillBelt {

    public override void init(unitControler controler, List<int> skillNos)
    {
        base.init(controler, skillNos);
        ((comboControler)controler).counterSkill = skills[0];
    }
}
