using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_sacredArmor : skill_representation
{
    public string Explanation
    {
        get
        {
            return "對我方最前排的一個隨機單位使用,優先選擇本單位前方的我方單位使用,該單位獲得神聖裝甲裝狀態:護甲+30,每秒恢復+3.持續5秒";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_sacredArmor";
        }
    }

    public string SkillName
    {
        get
        {
            return "神聖裝甲";
        }
    }

    public void init(unitData nowdata)
    {

    }
}
