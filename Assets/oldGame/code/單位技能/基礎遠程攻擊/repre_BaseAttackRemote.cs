using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_BaseAttackRemote : skill_representation {
    protected unitData data;
    public string Explanation
    {
        get
        {
            return "你再猜";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_BaseAttackRemote";
        }
    }

    public string SkillName
    {
        get
        {
            return "基礎遠程攻擊";
        }
    }

    public void init(unitData nowdata)
    {
        data = nowdata;
    }


}
