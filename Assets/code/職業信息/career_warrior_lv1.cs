﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class career_warrior_lv1 : careerInf {
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.atk, 2 }, { (byte)unitData.attribute.armor, 10 }, { (byte)unitData.attribute.life, 20 } };
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
            return "天堂在左,戰士在右";
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
            return "新手戰士";
        }
    }

    public List<int> nexrCareer
    {
        get
        {
            return new List<int> {6};
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
            return new List<int> {7};
        }
    }
    public List<int> giftSkills
    {
        get
        {
            return new List<int>() {0};
        }
    }

}
