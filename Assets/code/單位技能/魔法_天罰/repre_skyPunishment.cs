using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_skyPunishment : skill_representation {
    public string Explanation
    {
        get
        {
            return "對3個隨機敵人造成5-15點電魔法傷害";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_skyPunishment";
        }
    }

    public string SkillName
    {
        get
        {
            return "天罰";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}

