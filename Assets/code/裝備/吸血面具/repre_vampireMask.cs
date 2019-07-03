using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_vampireMask : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { };
        }
    }

    public string Commentary
    {
        get
        {
            return "做成毛血旺會比較好入口";
        }
    }

    public string Explanation
    {
        get
        {
            return "恢復造成物理傷害的10%";
        }
    }

    public string itemName
    {
        get
        {
            return "吸血面具";
        }
    }

    public int Price
    {
        get
        {
            return 6;
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_phyVampire10";//需要實做這個技能
        }
    }

    public void init(unitData nowdata)
    {
        
    }
    public List<int> Parts
    {
        get
        {
            return null;
        }
    }
}
