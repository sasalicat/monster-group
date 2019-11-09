using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_bloodSlam : skill_representation
{

    public string Explanation
    {
        get
        {
            return "對自身造成10%生命值上限的真實傷害,對目標造成等於20%生命值上限的物理傷害,對目標距離1的敵方角色造成等於10%生命值上限的物理傷害";
        }
    }




    public string ScriptName
    {
        get
        {
            return "skill_bloodSlam";
        }
    }

    public string SkillName
    {
        get
        {
            return "浴血猛擊";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
