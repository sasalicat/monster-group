using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class race_boarMan : careerInf
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.armor, 30 }, { (byte)unitData.attribute.mg_resist, 30 }, { (byte)unitData.attribute.life,40} };
        }
    }

    public int careerNo
    {
        get
        {
            return 5;
        }
    }

    public string Commentary
    {
        get
        {
            return "曾和猢猻出演過<<西遊記>>";
        }
    }

    public int frontCareer
    {
        get
        {
            return -1;
        }
    }

    public string name
    {
        get
        {
            return "野豬人";
        }
    }

    public List<int> nexrCareer
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
            return 5;
        }
    }

    public List<int> skillPool
    {
        get
        {
            return new List<int>() { };
        }
    }

}
