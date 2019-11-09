using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_heavyAxe : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { {(byte)unitData.attribute.atk,6} };
        }
    }

    public string Commentary
    {
        get
        {
            return "殺死你的是斧王";
        }
    }

    public string Explanation
    {
        get
        {
            return "攻擊力+7";
        }
    }

    public string itemName
    {
        get
        {
            return "重斧";
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
            return 9;
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
