using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill:MonoBehaviour {
    public SkillInf information;
    protected unitControler owner;
    public abstract void onInit(unitControler owner);
    public abstract void trigger(Dictionary<string,object> args);
    public abstract unitControler[] findTraget(Environment env);
    public virtual void arouse(Environment env)
    {
        unitControler[] tragets = findTraget(env);
        ((BasicControler)owner).useSkill(this,tragets);
    }
    public abstract bool canUse
    {
        get;
    }
    public unitControler Owner
    {
        get
        {
            return owner;
        }
    }
}
