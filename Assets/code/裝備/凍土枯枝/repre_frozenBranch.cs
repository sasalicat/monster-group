using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_frozenBranch : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() {{(byte)unitData.attribute.magic,70}};
        }
    }

    public string Commentary
    {
        get
        {
            return "搭配厚綿手套使用效果最佳";
        }
    }

    public string Explanation
    {
        get
        {
            return "智力+70,冰系技能冷卻-25%";
        }
    }

    public string itemName
    {
        get
        {
            return "凍土枯枝";
        }
    }

    public List<int> Parts
    {
        get
        {
            return new List<int>() { 8, 13, 13 };
        }
    }

    public int Price
    {
        get
        {
            return 0;
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_iceAccelerate";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
