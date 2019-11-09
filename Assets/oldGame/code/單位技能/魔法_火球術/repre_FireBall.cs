using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_FireBall : skill_representation
{
    public string Explanation
    {
        get
        {
            return "歡迎加入五火球神教!";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_FireBall";
        }
    }

    public string SkillName
    {
        get
        {
            return "火球術";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
