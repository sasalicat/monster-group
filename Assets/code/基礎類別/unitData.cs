using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitData  {
    public enum  attribute:byte {atk,atk_spd,magic,armor,life,recover,cd,mg_resist};
    public delegate void withFloat2(float arg1, float arg2);

    public const int BASE_ABILITY_NUMBER = 100;
    public const int STAND_ATK = 10;
    public const float STAND_ATK_INTERVAL = 1.0f;
    public const float STAND_RECOVER_INTERVAL = 1.0f;
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
    public BasicDelegate.withNone _onDeath;
    public withFloat2 _onCoolDownMutipleChange;
    private bool remote=false;
    public static float calReduce(int strength,int basic)
    {
        if (strength >= 0)
            return (float)basic / ((float)basic + (float)strength);
        else
            return ((float)basic - (float)strength) / (float)basic;
    }
    public static float calIncrease(int strength,int basic)
    {
        if (strength >= 0)
            return ((float)basic +(float)strength) / (float)basic;
        else
            return (float)basic / ((float)basic - (float)strength);
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
            else if (value > 0)
            {
                now_life_point = value;
            }
            else
            {
                now_life_point = 0;
                Debug.Log("設置now_life_point為:" + now_life_point);
                if (_onDeath!=null)
                {
                    _onDeath();
                }
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
            if(_onCoolDownMutipleChange!=null)
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
    public unitData_Profile getProflie()
    {
        return new unitData_Profile(base_attack,attack_speed_reinforce,magic_strength,armor,max_life_point,
            now_life_recover,cooldown_reinforce,magic_resistance);
    }
    public unitData(unitData_Profile profile)
    {
        this.base_attack = profile.base_attack;
        this.attack_speed_reinforce = profile.attack_speed_reinforce;
        this.max_life_point = profile.max_life_point;
        this.now_life_recover = profile.now_life_recover;
        this.magic_strength = profile.magic_strength;
        this.cooldown_reinforce = profile.cooldown_reinforce;
        this.armor = profile.armor;
        this.magic_resistance = profile.magic_resistance;
        this.now_life_point = max_life_point;

    }
    public unitData()
    {

    }
    public static string getAttributeString(attribute key) {
        switch (key) {
            case attribute.atk: {
                    return "攻擊力";
                }
            case attribute.atk_spd: {
                    return "攻速加成";
                }
            case attribute.magic:
                {
                    return "智力";
                }
            case attribute.armor:
                {
                    return "護甲";
                }
            case attribute.life: {
                    return "生命值上限";
                }
            case attribute.recover:
                {
                    return "每秒恢復";
                }
            case attribute.cd:
                {
                    return "冷卻強化";
                }
            case attribute.mg_resist:
                {
                    return "抗性";
                }
            default:
                {
                    return null;
                }
        }
    }
    public static string getAttributeString(byte key)
    {
        switch (key)
        {
            case (byte)attribute.atk:
                {
                    return "攻擊力";
                }
            case (byte)attribute.atk_spd:
                {
                    return "攻速加成";
                }
            case (byte)attribute.magic:
                {
                    return "智力";
                }
            case (byte)attribute.armor:
                {
                    return "護甲";
                }
            case (byte)attribute.life:
                {
                    return "生命值上限";
                }
            case (byte)attribute.recover:
                {
                    return "每秒恢復";
                }
            case (byte)attribute.cd:
                {
                    return "冷卻強化";
                }
            case (byte)attribute.mg_resist:
                {
                    return "抗性";
                }
            default:
                {
                    return null;
                }
        }
    }
    public Dictionary<byte,int> attributeUpdate
    {
        set
        {
            foreach (KeyValuePair<byte,int> pair in value)
            {
                switch (pair.Key)
                {
                    case (byte)attribute.atk:
                        Now_Attack += pair.Value;
                        break;
                    case (byte)attribute.atk_spd:
                        Now_Attack_Speed += pair.Value;
                        break;
                    case (byte)attribute.magic:
                        Now_Mag_Reinforce += pair.Value;
                        break;
                    case (byte)attribute.armor:
                        Now_Armor += pair.Value;
                        break;
                    case (byte)attribute.life:
                        Now_Max_Life += pair.Value;
                        break;
                    case (byte)attribute.recover:
                        Now_Life_Recover += pair.Value;
                        break;
                    case (byte)attribute.cd:
                        Now_Cooldown_Reinforce += pair.Value;
                        break;
                    case (byte)attribute.mg_resist:
                        Now_Mag_Resistance += pair.Value;
                        break;
                }
            }
        }
    }
    public Dictionary<byte, int> attributeDeny {
        set
        {
            foreach (KeyValuePair<byte, int> pair in value)
            {
                switch (pair.Key)
                {
                    case (byte)attribute.atk:
                        Now_Attack -= pair.Value;
                        break;
                    case (byte)attribute.atk_spd:
                        Now_Attack_Speed -= pair.Value;
                        break;
                    case (byte)attribute.magic:
                        Now_Mag_Reinforce -= pair.Value;
                        break;
                    case (byte)attribute.armor:
                        Now_Armor -= pair.Value;
                        break;
                    case (byte)attribute.life:
                        Now_Max_Life -= pair.Value;
                        break;
                    case (byte)attribute.recover:
                        Now_Life_Recover -= pair.Value;
                        break;
                    case (byte)attribute.cd:
                        Now_Cooldown_Reinforce -= pair.Value;
                        break;
                    case (byte)attribute.mg_resist:
                        Now_Mag_Resistance -= pair.Value;
                        break;
                }
            }
        }
    }
    public unitData(unitData another)
    {
        this.base_attack = another.base_attack;
        this.attack_speed_reinforce = another.attack_speed_reinforce;
        this.max_life_point = another.max_life_point;
        this.now_life_recover = another.now_life_recover;
        this.magic_strength = another.magic_strength;
        this.cooldown_reinforce = another.cooldown_reinforce;
        this.armor = another.armor;
        this.magic_resistance = another.magic_resistance;
        now_life_point = max_life_point;
    }
}

