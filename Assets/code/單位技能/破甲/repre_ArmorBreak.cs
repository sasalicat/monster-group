using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_ArmorBreak : skill_representation
{
    public string Explanation
    {
        get
        {
            return "只會破壞重甲,不會破壞貼身衣物";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_ArmorBreak";
        }
    }

    public string SkillName
    {
        get
        {
            return "破甲";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
