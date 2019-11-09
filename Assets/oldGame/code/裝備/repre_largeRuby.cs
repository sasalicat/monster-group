using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_largeRuby : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { {(byte)unitData.attribute.life,50} };
        }
    }

    public string Commentary
    {
        get
        {
            return "有些奸商把大塊紅寶石打碎成小塊紅寶石來販賣";
        }
    }

    public string Explanation
    {
        get
        {
            return "生命值+50";
        }
    }

    public string itemName
    {
        get
        {
            return "大塊紅寶石";
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
