using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitDataV2_profile : unitData_Profile {
    public int dodge_point;
    public int block_reduce;
    public int block_point;
    public float insight_reduce_rate;
    public float crit_magnification;
    public int crit_point;
    public int batter_limmit;
    public int batter_point;
    public int counter_point;
    public unitDataV2_profile(int base_attack, int attack_speed_reinforce, int magic_strength,
                            int armor, int max_life_point, int now_life_recover,
                            int cooldown_reinforce, int magic_resistance,
                            int dodge_point,int block_reduce,int block_point,
                            float insight_reduce_rate, float crit_magnification,int crit_point,
                            int batter_limmit,int batter_point,int counter_point) :base(base_attack, attack_speed_reinforce,magic_strength,
                                                                               armor, max_life_point,now_life_recover,
                                                                               cooldown_reinforce, magic_resistance)
    {
        this.dodge_point = dodge_point;
        this.block_reduce = block_reduce;
        this.block_point = block_point;
        this.insight_reduce_rate = insight_reduce_rate;
        this.crit_magnification = crit_magnification;
        this.crit_point = crit_point;
        this.batter_limmit = batter_limmit;
        this.batter_point = batter_point;
        this.counter_point = counter_point;
    }
}
