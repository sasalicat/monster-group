using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_electShield : buff_shieldTemplate
{

    public override GameObject effection_prefab
    {
        get
        {
            return objectList.main.prafebList[20];
        }
    }
    protected override void beforeDamage(Damage income)
    {
        Dictionary<string, object> buffArgs = new Dictionary<string, object>();
        buffArgs["time"] = 3.0f;
        buffArgs["layer"] = 1;
        buffArgs["creater"] = creater;
        income.creater.addBuff("buff_palsy", buffArgs);
    }

}
