using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_spider_poisonAttack : skill_representation
{
    public string Explanation
    {
        get
        {
            return "你好毒，你好毒，你好毒毒毒毒毒";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_spider_poison";
        }
    }

    public string SkillName
    {
        get
        {
            return "毒性攻擊";
        }
    }

    public void init(unitData nowdata)
    {

    }
}
