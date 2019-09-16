using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_thunderSprout : item_representation {
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.magic, 70 } };
        }
    }

    public string Commentary
    {
        get
        {
            return "简称雷霆芽";
        }
    }

    public string Explanation
    {
        get
        {
            return "智力+70,电系技能冷卻-25%";
        }
    }

    public string itemName
    {
        get
        {
            return "雷霆嫩芽";
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
            return "skill_thunderAccelerate";
        }
    }

    public void init(unitData nowdata)
    {

    }
}
