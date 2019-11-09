using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class career_pastor_lv1 : careerInf
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.magic, 20 }, { (byte)unitData.attribute.mg_resist, 20 },{ (byte)unitData.attribute.recover,1} };
        }
    }

    public int careerNo
    {
        get
        {
            return 17;
        }
    }

    public string Commentary
    {
        get
        {
            return "即使是野怪,只要信仰聖光也能成為牧師,只不過還是會被教會釘在十字架上燒死罷了";
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
            return "見習牧師";
        }
    }

    public List<int> nexrCareer
    {
        get
        {
            return new List<int> { 18 };
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
            return new List<int> { 52 };
        }
    }
    public List<int> giftSkills
    {
        get
        {
            return new List<int>() { 1 };
        }
    }
}

