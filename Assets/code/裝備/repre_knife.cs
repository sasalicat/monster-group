using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_knife : item_representation
{
    public void init(unitData data)
    {

    }
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { {(byte)unitData.attribute.atk, 3 } };
        }
    }

    public string Commentary
    {
        get
        {
            return "你在家附近的文具店付3金幣也能買到";
        }
    }

    public string Explanation
    {
        get
        {
            return "攻擊力+3";
        }
    }

    public string itemName
    {
        get
        {
            return "短刀";
        }
    }

    public int Price
    {
        get
        {
            return 3;
        }
    }

    public string ScriptName
    {
        get
        {
            return null;
        }
    }
}
