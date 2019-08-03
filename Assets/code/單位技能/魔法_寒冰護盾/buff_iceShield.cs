using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_iceShield : buff_shieldTemplate
{
    public override GameObject effection_prefab
    {
        get
        {
            return objectList.main.prafebList[27];
        }
    }

    protected override void beforeDamage(Damage income)
    {
        if (income.creater != null)
        {
            Dictionary<string, object> buffArgs = new Dictionary<string, object>();
            buffArgs["time"] = 3.0f;
            buffArgs["layer"] = 1;
            buffArgs["creater"] = creater;
            income.creater.addBuff("buff_chill", buffArgs);
        }
    }
}
