using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_shadowSacrifice : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.atk_spd, 60 }, { (byte)unitData.attribute.cd,60} };
        }
    }

    public string Commentary
    {
        get
        {
            return "暗影牧师进行仪式时使用的匕首,文化底蘊大於其鋒利程度";
        }
    }

    public string Explanation
    {
        get
        {
            return "攻速+60,冷卻+60";
        }
    }

    public string itemName
    {
        get
        {
            return "暗影祭祀";
        }
    }

    public List<int> Parts
    {
        get
        {
            return new List<int>() {11,14};
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
