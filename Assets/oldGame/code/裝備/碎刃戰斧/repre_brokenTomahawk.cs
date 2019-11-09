using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_brokenTomahawk : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.atk, 10 },};
        }
    }

    public string Commentary
    {
        get
        {
            return "曾是部落的英雄-加摩爾使用的武器,在斬殺了無數鋼鐵獸人後破損,被遺棄在了霜火嶺的白雪中";
        }
    }

    public string Explanation
    {
        get
        {
            return "攻擊力+10,被動:攻擊有25%的幾率造成額外50%的暴擊傷害";
        }
    }

    public string itemName
    {
        get
        {
            return "碎刃戰斧";
        }
    }

    public List<int> Parts
    {
        get
        {
            return new List<int>() {0,12};
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
            return "skill_critical_25p_15t";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
