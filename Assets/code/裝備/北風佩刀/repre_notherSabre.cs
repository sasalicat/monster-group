using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_notherSabre : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { {(byte)unitData.attribute.atk, 3 }, { (byte)unitData.attribute.atk_spd, 60 } };
        }
    }

    public string Commentary
    {
        get
        {
            return "風吹的我喘不過氣 --風行者";
        }
    }

    public string Explanation
    {
        get
        {
            return "攻擊力+3 攻擊速度+60,戰鬥開始時獲得輕盈 4秒";
        }
    }

    public string itemName
    {
        get
        {
            return "北風佩刀";
        }
    }

    public List<int> Parts
    {
        get
        {
            return new List<int>() { 0, 1 };
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
            return "skill_notherSabre";
        }
    }

    public void init(unitData nowdata)
    {
        
    }
}
