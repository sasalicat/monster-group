using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_stun : Buff
{

    protected BasicControler unit;
    protected GameObject effection;
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
            this.unit.state.CanAttack = false;
            this.unit.state.CanSkill = false;

            GameObject prefab = objectList.main.prafebList[6];
            effection = Instantiate(prefab, this.unit.transform);
            effection.transform.localPosition = prefab.transform.position; 
            return true;

        }
        else
        {
            if (((buff_stun)Repetitive[0]).TimeLeft<(float)args["time"]){
                ((buff_stun)Repetitive[0]).timeLeft = (float)args["time"];
            }
            return false;
        }
        
    }

    public override void onRemove()
    {
        unit.state.CanSkill = true;
        unit.state.CanAttack = true;
        Destroy(effection);
    }
}
