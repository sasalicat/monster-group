using System;
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
    public abstract unitControler[] findTraget(Environment env);
    public virtual void arouse(Environment env)
    {
        //Debug.Log("name:" + name + " owner:" + owner);
        unitControler[] tragets = findTraget(env);
        ((BasicControler)owner).useSkill(this, tragets);
    }
    public abstract bool canUse
    {
        get;
    }
    public float timeLeft = 0;
    public virtual void timePass(float time)
    {
        //Debug.Log("timeLeft 為" + timeLeft);
        if (timeLeft > 0)
        {
            timeLeft -= time;
        }
        //Debug.Log("timeLeft - time 後為:" + timeLeft);
    }
    public void setTime() {
        timeLeft = CoolDown;
    }

    public abstract void trigger(Dictionary<string, object> args);
}
