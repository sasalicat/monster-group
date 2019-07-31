using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class randomRepre : subst_skill_representation
{
    public abstract string Explanation
    {
        get;
    }

    public  abstract string ScriptName
    {
        get;
    }

    public abstract string SkillName
    {
        get;
    }

    public abstract void init(unitData nowdata);

    public abstract List<int> subsNos
    {
        get;
    }

    public int substitutNo()
    {
        int len = subsNos.Count;
        int index = UnityEngine.Random.Range(0, len);
        return subsNos[index];
    }
}
