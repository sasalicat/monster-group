using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_gladiatorSword : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.atk, 7 }, { (byte)unitData.attribute.recover, 4 } };
        }
    }

    public string Commentary
    {
        get
        {
            return "上面沾滿了角鬥士的鮮血,所以有活血通絡延年益壽的功能,我這麼說你會相信嗎?";
        }
    }

    public string Explanation
    {
        get
        {
            return "攻擊力+7,每秒恢復+4";
        }
    }

    public string itemName
    {
        get
        {
            return "角鬥士之劍";
        }
    }

    public List<int> Parts
    {
        get
        {
            return new List<int>() {12,6,6 };
        }
    }

    public int Price
    {
        get
        {
            return 0;
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
