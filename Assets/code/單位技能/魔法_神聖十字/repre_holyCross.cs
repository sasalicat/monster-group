using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_holyCross : skill_representation
{
    public string Explanation
    {
        get
        {
            return "治療受傷最多的我方的角色15點生命值,治療距離1的我方角色5點生命值";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_holyCross";
        }
    }

    public string SkillName
    {
        get
        {
            return "神聖十字";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
