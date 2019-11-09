using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_emeraldNecklace : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.cd, 60 } };
        }
    }

    public string Commentary
    {
        get
        {
            return "往往可以在女性的收藏中找到";
        }
    }

    public string Explanation
    {
        get
        {
            return "冷卻+60";
        }
    }

    public string itemName
    {
        get
        {
            return "翡翠項鏈";
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
