using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitData_Profile
{
    public int base_attack;
    public int attack_speed_reinforce;
    public int magic_strength;
    public int armor;
    public int max_life_point;
    public int now_life_recover;
    public int cooldown_reinforce;
    public int magic_resistance;
    public unitData_Profile(int base_attack, int attack_speed_reinforce, int magic_strength,
                            int armor, int max_life_point, int now_life_recover,
                            int cooldown_reinforce, int magic_resistance){
                                this.base_attack = base_attack;
                                this.attack_speed_reinforce = attack_speed_reinforce;
                                this.magic_strength = magic_strength;
                                this.armor = armor;
                                this.max_life_point = max_life_point;
                                this.now_life_recover = now_life_recover;
                                this.cooldown_reinforce = cooldown_reinforce;
                                this.cooldown_reinforce = cooldown_reinforce;
                                this.magic_resistance = magic_resistance;


    }
    public unitData_Profile()
    {

    }
}
