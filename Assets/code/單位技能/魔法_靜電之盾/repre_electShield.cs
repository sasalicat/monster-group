using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_electShield : skill_representation {
    public string Explanation
    {
        get
        {
            return "製造一個能吸收20點傷害的靜電之盾,攻擊有靜電之盾的角色會被麻痺!";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_electShield";
        }
    }

    public string SkillName
    {
        get
        {
            return "靜電之盾";
        }
    }

    public void init(unitData nowdata)
    {

    }

}
