﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class dynamicSkill : CDSkill {
    protected List<modifier> modifierList;
    protected abstract List<modifier> Modifiers
    {
        get;
    }
    public abstract SkillInf Inf();
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        modifierList = Modifiers;
        information = Inf();
        foreach(modifier mod in modifierList)
        {
            mod.traget = this;
            mod.onSkillInit(owner, deleg);
        }
        
    }
    public abstract unitControler[] getTragets(Environment env);
    public override unitControler[] findTraget(Environment env)
    {
        unitControler[] tragets= getTragets(env);
        foreach (modifier mod in modifierList)
        {
            mod.onFindTraget(env,ref tragets);
        }
        return tragets;
    }

}
