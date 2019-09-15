using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_necklace : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.cd, 20 } };
        }
    }

    public string Commentary
    {
        get
        {
            return "這條項鏈需要一顆寶石";
        }
    }

    public string Explanation
    {
        get
        {
            return "項鏈+20";
        }
    }

    public string itemName
    {
        get
        {
            return "項鏈";
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

    public void init(unitData nowdata)
    {
        
    }
}
