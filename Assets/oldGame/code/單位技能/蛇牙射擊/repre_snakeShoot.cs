using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_snakeShoot : skill_representation
{
    public string Explanation
    {
        get
        {
            return "對目標造成10點物理傷害,并造成2層中毒持續2.5秒";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_snakeShoot";
        }
    }

    public string SkillName
    {
        get
        {
            return "蛇牙射擊";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
