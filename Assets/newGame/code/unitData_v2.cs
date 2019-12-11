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
    public BasicDelegate.withFloat _onHpPercentageChange;
    public override int Now_Life
    {
        get
        {
            return now_life_point;
        }
        set
        {
            int before = now_life_point;
            if (value > Now_Max_Life)
            {
                now_life_point = Now_Max_Life;
            }
            else if (value > 0)
            {
                now_life_point = value;
            }
            else
            {
                now_life_point = 0;
                //Debug.Log("設置now_life_point為:" + now_life_point);
                if (_onDeath != null)
                {
                    _onDeath();
                }
                dead = true;
            }
            if (_onLifeChange != null)
                _onLifeChange(before);
            if (_onHpPercentageChange != null)
            {
                _onHpPercentageChange(((float)now_life_point)/((float)Now_Max_Life));
            }
        }
    }
    public override int Now_Max_Life
    {
        get
        {
            if (max_life_point >= 0)
            {
                return max_life_point;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            int oriMax = Now_Max_Life;
            max_life_point = value;
            if (Now_Max_Life > oriMax)//如果血上限增加了,當前血量也會增加
            {
                Now_Life += Now_Max_Life - oriMax;
            }

            if (Now_Max_Life < 0)//如果血上限小於0,設置當前血量為0
            {
                Now_Life = 0;
            }
            else if (Now_Max_Life < Now_Life)//如果血上限比血量還少,這降低當前血量到血上限
            {
                Now_Life = Now_Max_Life;
            }
            if (_onHpPercentageChange!=null)
            {
                _onHpPercentageChange(((float)now_life_point) / ((float)Now_Max_Life));
            }
        }
    }
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
            return 1f;
        }
    }
    public override unitData_Profile getProflie()
    {
        return new unitDataV2_profile(base_attack,attack_speed_reinforce,magic_strength,armor,max_life_point,now_life_recover,cooldown_reinforce,magic_resistance,dodge_point,block_reduce,block_point,insight_reduce_rate,crit_magnification,crit_point,batter_limmit,batter_point,counter_point);
    }
    public unitData_v2(unitData_v2 another) : base(another)
    {
        this.dodge_point = another.dodge_point;
        this.block_reduce = another.block_reduce;
        this.block_point = another.block_point;
        this.insight_reduce_rate = another.insight_reduce_rate;
        this.crit_magnification = another.crit_magnification;
        this.crit_point = another.crit_point;
        this.batter_limmit = another.batter_limmit;
        this.batter_point = another.batter_point;
        this.counter_point = another.counter_point;
    }
    public unitData_v2(unitData_Profile profile) : base(profile)
    {
        unitDataV2_profile profile_v2 = (unitDataV2_profile)profile;
        this.dodge_point = profile_v2.dodge_point;
        this.block_reduce = profile_v2.block_reduce;
        this.block_point = profile_v2.block_point;
        this.insight_reduce_rate = profile_v2.insight_reduce_rate;
        this.crit_magnification = profile_v2.crit_magnification;
        this.crit_point = profile_v2.crit_point;
        this.batter_limmit = profile_v2.batter_limmit;
        this.batter_point = profile_v2.batter_point;
        this.counter_point = profile_v2.counter_point;
    }
    public unitData_v2() : base()
    {

    }
}
