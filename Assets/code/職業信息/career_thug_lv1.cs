using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class career_thug_lv1 : careerInf
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.atk, 3 }, { (byte)unitData.attribute.atk_spd, 10 }, { (byte)unitData.attribute.life, 10 } };
        }
    }

    public int careerNo
    {
        get
        {
            return 8;
        }
    }

    public string Commentary
    {
        get
        {
            return "如果你在找暴徒的話,去西部荒野看看吧";
        }
    }

    public int frontCareer
    {
        get
        {
            return -1;
        }
    }

    public List<int> giftSkills
    {
        get
        {
            return new List<int>() { 0 };
        }
    }

    public string name
    {
        get
        {
            return "剛入伙的暴徒";
        }
    }

    public List<int> nexrCareer
    {
        get
        {
            return new List<int> { 9 };
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
            return new List<int> { 10 };
        }
    }

}
