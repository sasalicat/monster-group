using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_disarm : Buff {
    GameObject effection;
    public override float Duration
    {
        get
        {
            return 0;
        }
    }

    public override bool onInit(unitControler unit, Buff[] Repetitive, Dictionary<string, object> args)
    {
        //Debug.Log("總共有" + Repetitive.Length + "個重複Buff");
        if (Repetitive.Length == 0)
        {
            timeLeft = (float)args["time"];
            this.unit = (BasicControler)unit;
            ((BasicControler)this.unit).state.CanAttack = false;

            GameObject prefab = objectList.main.prafebList[37];
            effection = Instantiate(prefab, ((BasicControler)this.unit).transform);
            effection.transform.localPosition = prefab.transform.position;
            return true;

        }
        else
        {
            if (((buff_disarm)Repetitive[0]).TimeLeft < (float)args["time"])
            {
                ((buff_disarm)Repetitive[0]).timeLeft = (float)args["time"];
            }
            return false;
        }

    }

    public override void onRemove()
    {
        Destroy(effection);
        ((BasicControler)this.unit).state.CanAttack = true;
    }
}
