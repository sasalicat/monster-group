using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_slowHealing : skill_representation
{
    public string Explanation
    {
        get
        {
            return "所有生命值小於60%的角色獲得緩慢治療狀態2秒,若沒用角色生命值小於60%,則僅對受傷最多的我方角色使用";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_slowHealing";
        }
    }

    public string SkillName
    {
        get
        {
            return "緩慢治療";
        }
    }

    public void init(unitData nowdata)
    {
    }
        
}
