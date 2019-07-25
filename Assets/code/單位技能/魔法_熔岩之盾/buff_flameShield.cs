using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_flameShield : Buff
{
    GameObject effection;
    BasicControler creater;
    public int shieldNum;
    private float trigger_time_left;
    private readonly float TriggerTime = 0.2f;
    public override float Duration
    {
        get
        {
            return 0;
        }
    }
    public void beforeTakeDamage(Damage d)
    {
        Dictionary<string, object> buffArgs = new Dictionary<string, object>();
        buffArgs["time"] = 3.0f;
        buffArgs["layer"] = 1;
        buffArgs["creater"] = creater;
        d.creater.addBuff("buff_burn", buffArgs);
        if (d.num > shieldNum)
        {
            d.num -= shieldNum;
            //Debug.LogWarning("盾")
            shieldNum = 0;
            deleteSelf();
        }
        else
        {
            shieldNum -= d.num;
            d.num = 0;
            if(shieldNum <= 0)
            {
                deleteSelf();
            }
        }
    }
    public override bool onInit(unitControler unit, Buff[] Repetitive, Dictionary<string, object> args)
    {
        if (Repetitive.Length == 0)
        {
            timeLeft = (float)args["time"];
            shieldNum = (int)args["num"];
            creater = (BasicControler)args["creater"];
            this.unit = (BasicControler)unit;


            GameObject prefab = objectList.main.prafebList[16];
            effection = Instantiate(prefab, ((BasicControler)this.unit).transform);
            effection.transform.localPosition = prefab.transform.position;
            ((BasicControler)unit)._befTakeDamage += beforeTakeDamage; 
            return true;

        }
        else
        {
            if (((buff_flameShield)Repetitive[0]).TimeLeft < (float)args["time"])
            {
                ((buff_flameShield)Repetitive[0]).timeLeft = (float)args["time"];
            }
            if (((buff_flameShield)Repetitive[0]).shieldNum < (int)args["num"])
            {
                ((buff_flameShield)Repetitive[0]).shieldNum = (int)args["num"];
            }
            return false;
        }

    }
    public override void onIntarvel(unitControler unit, float timeBetween)
    {
        trigger_time_left -= timeBetween;
        if (trigger_time_left <= 0)
        {
            trigger_time_left = TriggerTime;
            //int num = 1;
        }
        base.onIntarvel(unit, timeBetween);
    }
    public override void onRemove()
    {
        //Debug.LogWarning("flame shield onRemove!!!");
        Destroy(effection);
    }
}
