using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_plate : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>()
            {
                {(byte)unitData.attribute.armor,60}
            };
        }
    }

    public string Commentary
    {
        get
        {
            return "戰士,聖騎士,死亡騎士可以使用";
        }
    }

    public string Explanation
    {
        get
        {
            return "護甲+60";
        }
    }

    public string itemName
    {
        get
        {
            return "板甲";
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
