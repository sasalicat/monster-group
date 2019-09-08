using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_lightBarrier : skill_representation
{
    public string Explanation
    {
        get
        {
            return "在遊戲開始時,所有我方角色獲得一個等於本角色智力一半的護盾";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_lightBarrier";
        }
    }

    public string SkillName
    {
        get
        {
            return "光之屏障";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
