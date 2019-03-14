using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill:MonoBehaviour {
    public SkillInf information;
    protected BasicControler owner;
    public abstract void onInit(unitControler owner,Callback4Unit deleg);
    public const string ARG_MISS = "miss";
    public const string ARG_DICE = "dice";
    public const string ARG_PHY_MUL = "phy_damage_multiple";
    public const string ARG_PHY_ADD = "phy_damage_addition";
    public const string ARG_MAG_MUL = "mag_damage_multiple";
    public const string ARG_MAG_ADD = "mag_damage_addition";
    public const string ARG_HEAL_MUL = "healing_multiple";
    public const string ARG_HEAL_ADD = "healing_addition";
    public const string ARG_CONTROL_MUL = "control_multiple";
    public const string ARG_CONTROL_ADD = "control_addition";
    public unitControler Owner
    {
        get
        {
            return owner;
        }
    }
}
