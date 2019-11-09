using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class race_orc : careerInf
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { {(byte)unitData.attribute.atk,5}, { (byte)unitData.attribute.life, 50 } };
        }
    }

    public int careerNo
    {
        get
        {
            return 0;
        }
    }

    public string Commentary
    {
        get
        {
            return "獸人永不為奴!除非包吃包住";
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
            return "獸人";
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
            return new List<int>() {  };
        }
    }
    public List<int> giftSkills
    {
        get
        {
            return new List<int>() { 2};
        }
    }
}
