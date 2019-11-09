using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_glove : item_representation
{
    public void init(unitData data)
    {

    }
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.atk_spd, 20 } };
        }
    }

    public string Commentary
    {
        get
        {
            return "和食人魔沒有關係!";
        }
    }

    public string Explanation
    {
        get
        {
            return "攻擊速度+20";
        }
    }

    public string itemName
    {
        get
        {
            return "拳套";
        }
    }

    public int Price
    {
        get
        {
            return 2;
        }
    }

    public string ScriptName
    {
        get
        {
            return null;
        }
    }

    public List<int> Parts
    {
        get
        {
            return null;
        }
    }
}
