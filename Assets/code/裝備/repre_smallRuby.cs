﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_smallRuby : item_representation
{
    public void init(unitData data)
    {

    }
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.life, 30 } };
        }
    }

    public string Commentary
    {
        get
        {
            return "學名叫聚甲基丙烯酸甲酯";
        }
    }

    public string Explanation
    {
        get
        {
            return "生命值+30";
        }
    }

    public string itemName
    {
        get
        {
            return "小塊紅寶石";
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
    public List<int> Parts
    {
        get
        {
            return null;
        }
    }
}
