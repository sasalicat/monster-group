using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_woodenStick : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.magic,70} };
        }
    }

    public string Commentary
    {
        get
        {
            return "木棍的雅稱";
        }
    }

    public string Explanation
    {
        get
        {
            return "智力+70";
        }
    }

    public string itemName
    {
        get
        {
            return "木杖";
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
