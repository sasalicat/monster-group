using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Callback4Unit_v2 : Callback4Unit
{
    BasicDelegate.withDamage _aftCrit
    {
        set;
        get;
    }
    BasicDelegate.withDamage _aftBlock
    {
        set;
        get;
    }
    BasicDelegate.forSkill _aftDodge
    {
        set;
        get;
    }
}
