using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_headerchief : item_representation
{
    public void init(unitData data)
    {

    }
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.mg_resist, 20 } };
        }
    }

    public string Commentary
    {
        get
        {
            return "印度人用過";
        }
    }

    public string Explanation
    {
        get
        {
            return "魔抗+20";
        }
    }

    public string itemName
    {
        get
        {
            return "頭巾";
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
