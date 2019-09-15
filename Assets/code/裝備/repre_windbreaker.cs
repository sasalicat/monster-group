using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_windbreaker : item_representation
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { {(byte)unitData.attribute.mg_resist,70} };
        }
    }

    public string Commentary
    {
        get
        {
            return "因为没有风系魔法，所以并不能防风";
        }
    }

    public string Explanation
    {
        get
        {
            return "魔抗+70";
        }
    }

    public string itemName
    {
        get
        {
            return "風衣";
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
