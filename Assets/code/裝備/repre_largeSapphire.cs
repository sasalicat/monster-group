using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_largeSapphire : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { {(byte)unitData.attribute.magic,50} };
        }
    }

    public string Commentary
    {
        get
        {
            return "也有奸商把大塊紅寶石染成藍寶石來販賣?";
        }
    }

    public string Explanation
    {
        get
        {
            return "智力+50";
        }
    }

    public string itemName
    {
        get
        {
            return "大塊藍寶石";
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
            return 6;
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
