using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitData_v2 : unitData {
    const int STAND_DODGE = 0;
    const int STAND_BLOCK = 0;
    const int STAND_INSIGHT = 0;
    const int STAND_CRIT = 0;
    const int STAND_BATTER = 0;
    const int STAND_COUNTER = 0;

    private int dodge_point = STAND_DODGE;
    public int Now_Dodge_Point
    {
        get
        {
            return dodge_point;
        }
        set
        {
            dodge_point = value;
        }
    }

    private int block_point = STAND_BLOCK;
    public int Now_Block_Point
    {
        get
        {
            return block_point;
        }
        set
        {
            block_point = value;
        }
    }

    private int insight_point = STAND_INSIGHT;
    public int Now_Insight_Point
    {
        get
        {
            return insight_point;
        }
        set
        {
            insight_point = value;
        }
    }

    private int crit_point = STAND_CRIT;
    public int Now_Crit_Point
    {
        get
        {
            return crit_point;
        }
        set
        {
            crit_point = value;
        }
    }

    private int batter_point = STAND_BATTER;
    public int Now_Batter_Point
    {
        get
        {
            return batter_point;
        }
        set
        {
            batter_point = value;
        }
    }

    private int counter_point = STAND_COUNTER;
    public int Now_Counter_Point
    {
        get
        {
            return counter_point;
        }
        set
        {
            counter_point = value;
        }
    } 

}
