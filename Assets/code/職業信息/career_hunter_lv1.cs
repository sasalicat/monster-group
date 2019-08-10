using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class career_hunter_lv1 : careerInf
{
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.atk, 2 }, { (byte)unitData.attribute.atk_spd, 10 }, { (byte)unitData.attribute.cd,10}, { (byte)unitData.attribute.life,10} };
        }
    }

    public int careerNo
    {
        get
        {
            return 14;
        }
    }

    public string Commentary
    {
        get
        {
            return "殺死獵物的不是道具也不是其技術,都只是自身那清澈如水的殺意";
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
            return new List<int>() { 1 };
        }
    }

    public string name
    {
        get
        {
            return "菜鳥級獵人";
        }
    }

    public List<int> nexrCareer
    {
        get
        {
            return new List<int>() {15};
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
            return new List<int>() {43};
        }
    }
}
