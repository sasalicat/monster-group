using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CDSkill : Skill {
    protected float cdMutiple = 1f; 

    public abstract float StandCoolDown
    {
        get;
    }
    public float CoolDown
    {
        get
        {
            return cdMutiple * StandCoolDown;
        }
    } 
    public float timeLeft = 0;
    public virtual void timePass(float time)
    {
        if (timeLeft > 0)
        {
            timeLeft -= time;
        }
    }

}
