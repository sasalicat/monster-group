using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_greedyBlade : item_representation {
    public Dictionary<byte, int> Attributes
    {
        get
        {
            return new Dictionary<byte, int>() { { (byte)unitData.attribute.atk, 5 } };
        }
    }

    public string Commentary
    {
        get
        {
            return "這是一把活體刀刃,渴望著鮮血,據說是某個叫泰倫的遙遠宇宙的種族所製造";
        }
    }

    public string Explanation
    {
        get
        {
            return "攻擊力+5,物理吸血25%";
        }
    }

    public string itemName
    {
        get
        {
            return "貪婪之刃";
        }
    }

    public List<int> Parts
    {
        get
        {
            return new List<int>() {0,0,7,7};
        }
    }

    public int Price
    {
        get
        {
            return 0;
        }
    }

    public string ScriptName
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public void init(unitData nowdata)
    {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
