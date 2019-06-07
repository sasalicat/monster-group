using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_leather : item_representation
{
    public void init(unitData data)
    {

    }
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { {(byte)unitData.attribute.armor,30} };
        }
    }

    public string Commentary
    {
        get
        {
            return "除了牧師,法師,術士以外均可裝備";
        }
    }

    public string Explanation
    {
        get
        {
            return "護甲+30";
        }
    }

    public string itemName
    {
        get
        {
            return "皮甲";
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
