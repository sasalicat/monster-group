using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_lightingChain : skill_representation
{
    public string Explanation
    {
        get
        {
            return "對當前目標造成6點電魔法傷害,每造成一次傷害若距離1有其他單位,則對距離1的隨機單位造成當前傷害-1的傷害,最多重複5次";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_lightingChain";
        }
    }

    public string SkillName
    {
        get
        {
            return "閃電鏈";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
