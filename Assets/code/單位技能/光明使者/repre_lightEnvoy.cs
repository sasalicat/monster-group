using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_lightEnvoy : skill_representation
{

    // Use this for initialization
    public string Explanation
    {
        get
        {
            return "本角色所有技能的治療量增加30%,每秒生命恢復+2\n\n烏瑟爾:???";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_lightEnvoy";
        }
    }

    public string SkillName
    {
        get
        {
            return "光明使者";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
