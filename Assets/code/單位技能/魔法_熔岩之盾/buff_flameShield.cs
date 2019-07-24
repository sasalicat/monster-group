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
        if (d.num > shieldNum)
        {
            d.num -= shieldNum;
            shieldNum = 0;
            deleteSelf();
        }
        else
        {
            shieldNum -= d.num;
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
            int num = 1;
        }
        base.onIntarvel(unit, timeBetween);
    }
    public override void onRemove()
    {
        Destroy(effection);
    }
}
