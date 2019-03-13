using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill:MonoBehaviour {
    public SkillInf information;
    protected BasicControler owner;
    public abstract void onInit(unitControler owner,Callback4Unit deleg);

    public unitControler Owner
    {
        get
        {
            return owner;
        }
    }
}
