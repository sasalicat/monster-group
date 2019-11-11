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
    const int BASE_BLOCK_REDUCE = STAND_ATK;
    const int BASE_BATTER_LIMMIT = 1;
    const float BASE_CRIT_MAGNIF = 2;
    const float BASE_INSIGHT_REDUCE_RATE = 0.5f;

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
    public float Now_Dodge_Rate
    {
        get
        {
            return 0.5f;
        }
    }
    private int block_reduce=BASE_BLOCK_REDUCE;
    public virtual int blockReduceNum {
        get
        {
            return block_reduce;
        }
        set
        {
            block_reduce = value;
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
    public float Now_Block_Rate
    {
        get
        {
            return 0.5f;
        }
    }
    private float insight_reduce_rate = BASE_INSIGHT_REDUCE_RATE;
    public float Now_Insight_Reduce
    {
        get
        {
            return insight_reduce_rate;
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
    public float Now_Insight_Rate
    {
        get
        {
            return 0.5f;
        }
    }
    private float crit_magnification = BASE_CRIT_MAGNIF;
    public float Now_Crit_Magnif
    {
        get
        {
            return crit_magnification;
        }
        set
        {
            if (value >= 0)
            {
                crit_magnification = value;
            }
            else
            {
                crit_magnification = 0;
            }
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
    public float Now_Crit_Rate
    {
        get
        {
            return 0.5f;
        }
    }
    private int batter_limmit = BASE_BATTER_LIMMIT;
    public int Now_Batter_Limmit
    {
        get
        {
            return batter_limmit;
        }
        set
        {
            if (value > BASE_BATTER_LIMMIT)
            {
                batter_limmit = value;
            }
            else
            {
                batter_limmit = BASE_BATTER_LIMMIT;
            }
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
    public float Now_Batter_Rate{
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
    public float Now_Counter_Rate
    {
        get
        {
            return 0.5f;
        }
    }
}
