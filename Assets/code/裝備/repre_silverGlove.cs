using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_silverGlove : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.atk_spd, 60 } };
        }
    }

    public string Commentary
    {
        get
        {
            return "很可能是鍍上去的";
        }
    }

    public string Explanation
    {
        get
        {
            return "攻速+60";
        }
    }

    public string itemName
    {
        get
        {
            return "銀拳套";
        }
    }

    public List<int> Parts
    {
        get
        {
            return null;
        }
    }

    public int Price
    {
        get
        {
            return 7;
        }
    }

    public string ScriptName
    {
        get
        {
            return null;
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
