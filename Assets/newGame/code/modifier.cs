using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class modifier{
    public CDSkill traget;
    public abstract void onSkillInit(unitControler owner, Callback4Unit deleg);
    //public abstract void ModifyDamager(Damage d);
    //public abstract void aftSkillEnd();
    public virtual void onFindTraget(Environment env, ref unitControler[] tragets) { }
}
