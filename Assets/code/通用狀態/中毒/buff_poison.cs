﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_poison : Buff {
    public int layer;
    public const int MAX_LAYER= 10;
    public const int DAMAGE_PER_LAYER = 2;
    //protected BasicControler unit;
    protected GameObject effection;
    protected BasicControler creater;
    public readonly float TriggerCycle = unitData.STAND_ATK_INTERVAL/2;
    public float trigger_time_left;
    public override float Duration
    {
        get
        {
            return 0;
        }
    }
    private void befHeal(HealMsg msg)
    {
        msg.num = (int)(msg.num * 0.5f);
    }
    public override bool onInit(unitControler unit, Buff[] Repetitive, Dictionary<string, object> args)
    {
        int selfLayer = (int)args["layer"];
        //Debug.Log("總共有" + Repetitive.Length + "個重複Buff");
        creater = (BasicControler)args["creater"];
        if (Repetitive.Length == 0)
        {

            layer = selfLayer;
            trigger_time_left = TriggerCycle;
            timeLeft = (float)args["time"];
            this.unit = (BasicControler)unit;

            ((BasicControler)unit)._befHealing += befHeal;
            GameObject prefab = objectList.main.prafebList[33];
            effection = Instantiate(prefab, ((BasicControler)this.unit).transform);
            effection.transform.localPosition = new Vector2(0, -0.67f);
            return true;

        }
        else
        {
            buff_poison before = ((buff_poison)Repetitive[0]);
            if (selfLayer + before.layer <= MAX_LAYER) {
                before.layer += selfLayer;
            }
            else {
                before.layer = MAX_LAYER;
            }
            if ((float)args["time"] > before.timeLeft)
            {
                before.timeLeft = (float)args["time"];
            }
            return false;

        }

    }
    public override void onIntarvel(unitControler unit, float timeBetween)
    {
        //Debug.Log("burn onIntarvel 被呼叫 time left:" + trigger_time_left);
        trigger_time_left -= timeBetween;
        if (trigger_time_left <= 0)
        {
            //Debug.Log("trigger_time_left 小於等於0 unit 名字:" + ((BasicControler)unit).gameObject.name + " layer:" + layer);
            this.unit.takeDamage(new Damage(layer * DAMAGE_PER_LAYER, Damage.KIND_REAL, creater));
            trigger_time_left = TriggerCycle;
        }
        base.onIntarvel(unit, timeBetween);

    }
    public override void onRemove()
    {
        Destroy(effection);
    }
}
