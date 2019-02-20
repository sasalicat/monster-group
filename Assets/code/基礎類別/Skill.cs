using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill {
    public SkillInf information;
    protected unitControler owner;
    public abstract void onInit(unitControler owner);
    public abstract void trigger(Dictionary<string,object> args);
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
