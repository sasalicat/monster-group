using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_recoverRing : item_representation
{
    public void init(unitData data)
    {

    }
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.recover, 2 } };
        }
    }

    public string Commentary
    {
        get
        {
            return "恢復是心理作用";
        }
    }

    public string Explanation
    {
        get
        {
            return "每秒恢復+2";
        }
    }

    public string itemName
    {
        get
        {
            return "恢復戒指";
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
}
