using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitData  {

    public delegate void withFloat2(float arg1, float arg2);

    public const int BASE_ABILITY_NUMBER = 100;
    public const int STAND_ATK = 10;
    public const float STAND_ATK_INTERVAL = 1.0f;
    public const int STAND_ATK_SPD_REINFORCE = 0;
    public const int STAND_MAG_REINFOCE = 0;
    public const int STAND_ARMOR = 0;
    public const int STAND_LIFE = 100;
    public const int STAND_LIFE_RECOVER = 0;
    public const int STAND_COOLDOWN_REINFORCE = 0;
    public const int STAND_MAG_RESISTANCE = 0;
    private int base_attack = STAND_ATK;
    private int attack_offset = 0;

    public BasicDelegate.withInt _onLifeChange;
    public withFloat2 _onCoolDownMutipleChange;
    private bool remote=false;
    public static float calReduce(int strength,int basic)
    {
        if (strength >= 0)
            return basic / (basic + strength);
        else
            return (basic - strength) / basic;
    }
    public static float calIncrease(int strength,int basic)
    {
        if (strength >= 0)
            return (basic + strength) / basic;
        else
            return basic / (basic - strength);
    }
    public bool Remote
    {
        get
        {
            return remote;
        }
    }
    public int Now_Attack
    {
        get
        {
            if (base_attack>=0)
            {
                return base_attack;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            base_attack = value;
        }
    }

    private int attack_speed_reinforce= STAND_ATK_SPD_REINFORCE;
    public int Now_Attack_Speed
    {
        set
        {
            attack_speed_reinforce = value;
        }
        get
        {
            return attack_speed_reinforce;
        }
    }
    public float Now_Attack_Interval
    {
        get
        {
            return STAND_ATK_INTERVAL * calReduce(Now_Attack_Speed, BASE_ABILITY_NUMBER);
        }
    }

    private int magic_strength = STAND_MAG_REINFOCE;
    public int Now_Mag_Reinforce
    {
        set
        {
            magic_strength = value;
        }
        get
        {
            return magic_strength;
        }
    }
    public float Now_Mag_Multiple
    {
        get
        {
            return calIncrease(magic_strength, BASE_ABILITY_NUMBER);
        }
    }

    private int armor = STAND_ARMOR;
    public int Now_Armor
    {
        set
        {
            armor = value;
        }
        get
        {
            return armor;
        }
    }
    public float Physical_Reduce_Multiple
    {
        get
        {
            return calReduce(armor, BASE_ABILITY_NUMBER);
        }
    }

    private int max_life_point = STAND_LIFE;

    public int Now_Max_Life
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
            
        }
    }

    private int now_life_point = STAND_LIFE;
    public int Now_Life
    {
        get
        {
            return now_life_point;
        }
        set
        {
            if (value > Now_Max_Life) {
                now_life_point = Now_Max_Life;
            }
            else if (value >= 0)
            {
                now_life_point = value;
            }
            else
            {
                now_life_point = 0;
                Debug.Log("設置now_life_point為:" + now_life_point);
            }
            if(_onLifeChange!=null)
                _onLifeChange(Now_Life);
        }
    }
    private int now_life_recover = STAND_LIFE_RECOVER;
    public int Now_Life_Recover
    {
        set
        {
            now_life_recover = value;
        }
        get
        {
            if (now_life_recover < 0)
            {
                return 0;
            }
            else
            {
                return now_life_recover;
            }
        }
    }
    private int cooldown_reinforce = STAND_COOLDOWN_REINFORCE;
    public int Now_Cooldown_Reinforce
    {
        set
        {
            int origen = cooldown_reinforce;
            cooldown_reinforce = value;
            _onCoolDownMutipleChange(calReduce(origen, BASE_ABILITY_NUMBER), calReduce(cooldown_reinforce, BASE_ABILITY_NUMBER));
        }
        get
        {
            return cooldown_reinforce;
        }
    }
    public float Now_Cooldown_Mutiple
    {
        get
        {
            return calReduce(cooldown_reinforce, BASE_ABILITY_NUMBER);
        } 
    }

    private int magic_resistance = STAND_MAG_RESISTANCE;
    public int Now_Mag_Resistance{
        set
        {
            magic_resistance = value;
        }
        get
        {
            return magic_resistance;
        }
    }
    public float Magic_Reduce_Multiple
    {
        get
        {
            return calReduce(magic_resistance, BASE_ABILITY_NUMBER);
        }
    }

}
