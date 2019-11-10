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
    //在確定計算公式前都用0.5湊合下
    public float Dodge_Rate
    {
        get
        {
            return 0.5f;
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
    public float Block_Rate
    {
        get
        {
            return 0.5f;
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
    public float Insight_Rate
    {
        get
        {
            return 0.5f;
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
    public float Crit_Rate
    {
        get
        {
            return 0.5f;
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
    public float Batter_Rate{
        get{
            return 0.5f;
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
    public float Counter_Rate
    {
        get
        {
            return 0.5f;
        }
    }
}
