using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_thunderHit : skill_representation {
    public string Explanation
    {
        get
        {
            return "對目標造成10點電魔法傷害,并麻痺3s";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_thunderHit";
        }
    }

    public string SkillName
    {
        get
        {
            return "雷擊";
        }
    }

    public void init(unitData nowdata)
    {

    }

}
