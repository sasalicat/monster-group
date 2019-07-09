using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class race_elf : careerInf {
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.atk_spd, 50 }, { (byte)unitData.attribute.cd, 50 } };
        }
    }

    public int careerNo
    {
        get
        {
            return 1;
        }
    }

    public string Commentary
    {
        get
        {
            return "巨魔的剋星,獸人的殺手,永恆之井的終結者";
        }
    }

    public string name
    {
        get
        {
            return "精靈";
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
            return new List<int>() {4};
        }
    }

}
