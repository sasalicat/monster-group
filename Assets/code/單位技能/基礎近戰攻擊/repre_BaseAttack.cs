using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_BaseAttack : skill_representation
{
    public  string Explanation
    {
        get
        {
            return "你猜";
        }
    }

    public  string ScriptName
    {
        get
        {
            return "skill_BaseAttack";
        }
    }

    public string SkillName
    {
        get
        {
            return "你猜";
        }
    }

    public void init(unitData nowdata)
    {
        throw new NotImplementedException();
    }
}
