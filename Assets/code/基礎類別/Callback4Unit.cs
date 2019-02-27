﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Callback4Unit {
    BasicDelegate.forSkill _BeAppoint
    {
        get;
        set;
    }
    BasicDelegate.forSkillTrageting _BefUseSkill
    {
        set;
        get;
    }
    BasicDelegate.withDamage _BefTakeDamage
    {
        set;
        get;
    }
    BasicDelegate.withDamage _AftTakeDamage
    {
        set;
        get;
    }
    BasicDelegate.withDamage _AftCauseDamage
    {
        set;
        get;
    }
}
