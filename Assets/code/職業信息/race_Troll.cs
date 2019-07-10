using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class race_troll: careerInf
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.atk, 2 }, { (byte)unitData.attribute.atk_spd, 25 }, { (byte)unitData.attribute.mg_resist, 25 }, { (byte)unitData.attribute.magic, 35 } };
        }
    }

    public int careerNo
    {
        get
        {
            return 2;
        }
    }

    public string Commentary
    {
        get
        {
            return "艾澤拉斯冒險者日常必做的三件事:吃飯,睡覺,打巨魔";
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
            return "巨魔";
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
            return new List<int>() { 3 };
        }
    }

}
