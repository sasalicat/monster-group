﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class modifier{
    public CDSkill traget;
    public abstract void onSkillInit(unitControler owner, Callback4Unit deleg);
    //public abstract void ModifyDamager(Damage d);
    //public abstract void aftSkillEnd();
    public virtual void onFindTraget(Environment env, ref unitControler[] tragets) { }
    public virtual string specificOnReadyKey(string oriKey) { return oriKey; }//警告:亂用這個function會導致技能的特效物件亂掉,或者技能特效物件方面的報錯
}
