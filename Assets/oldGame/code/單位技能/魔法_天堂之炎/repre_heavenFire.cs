using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_heavenFire : skill_representation
{
    public string Explanation
    {
        get
        {
            return "造成15點神聖屬性傷害,我方受到最多傷害的角色恢復15點生命值";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_heavenFire";
        }
    }

    public string SkillName
    {
        get
        {
            return "天堂之炎";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
