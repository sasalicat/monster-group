using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class race_lizardMan : careerInf
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.atk, 1 }, { (byte)unitData.attribute.armor, 10 } };
        }
    }

    public int careerNo
    {
        get
        {
            return 4;
        }
    }

    public string Commentary
    {
        get
        {
            return "魔古族出品,和龍人沒有關係";
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
            return "蜥蜴人";
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
    public List<int> giftSkills
    {
        get
        {
            return new List<int>();
        }
    }
}
