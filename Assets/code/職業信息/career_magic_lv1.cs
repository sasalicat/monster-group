using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class career_magic_lv1 : careerInf {
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.magic, 30 }, { (byte)unitData.attribute.mg_resist, 20 } };
        }
    }

    public int careerNo
    {
        get
        {
            return 11;
        }
    }

    public string Commentary
    {
        get
        {
            return "對於單身很久的男性的尊稱";
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
            return "學徒級巫師";
        }
    }

    public List<int> nexrCareer
    {
        get
        {
            return new List<int> { 12 };
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
            return new List<int> {32};
        }
    }
    public List<int> giftSkills
    {
        get
        {
            return new List<int>() {1};
        }
    }
}
