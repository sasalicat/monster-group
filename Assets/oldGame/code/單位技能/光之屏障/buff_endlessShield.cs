using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_endlessShield : buff_shieldTemplate {
    public override GameObject effection_prefab
    {
        get
        {
            return objectList.main.prafebList[32];
        }
    }

    protected override void beforeDamage(Damage income)
    {
        
    }
    public override bool endless
    {
        get
        {
            return true;
        }
    }
}
