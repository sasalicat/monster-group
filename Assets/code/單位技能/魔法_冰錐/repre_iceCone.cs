using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_iceCone : skill_representation
{
    public string Explanation
    {
        get
        {
            return "造成10點傷害,若目標有寒冷狀態則改為造成25點傷害";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_iceCone";
        }
    }

    public string SkillName
    {
        get
        {
            return "冰錐術";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
