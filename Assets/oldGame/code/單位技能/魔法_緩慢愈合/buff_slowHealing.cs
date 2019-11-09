using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_slowHealing : Buff {
    public override int kind
    {
        get
        {
            return POSITIVE;
        }
    }
    private GameObject effection;
    protected BasicControler creater;
    protected int number;
    public const float TIGGER_TIME = 0.5f * unitData.STAND_ATK_INTERVAL;
    protected float triggerLeft = TIGGER_TIME;
    public override float Duration
    {
        get
        {
            return 0;
        }
    }

    public override void onIntarvel(unitControler unit, float timeBetween)
    {
        triggerLeft -= timeBetween;
        if (triggerLeft <= 0){
            unit.heal(number,creater);
            triggerLeft = TIGGER_TIME;
        }
        base.onIntarvel(unit, timeBetween);

    }
    public override bool onInit(unitControler unit, Buff[] Repetitive, Dictionary<string, object> args)
    {
        int num = (int)args["num"];
        float time = (float)args["time"];
        creater = (BasicControler)args["creater"];
        if (Repetitive.Length > 0)
        {
            buff_slowHealing buff = (buff_slowHealing)Repetitive[0];
            if (buff.number < num)
            {
                buff.number = num;
            }
            if (buff.TimeLeft < time)
            {
                buff.timeLeft = time;
            }
            return false;
        }
        else
        {

            timeLeft = time;
            number = num;
            GameObject prafeb = objectList.main.prafebList[43];
            effection = Instantiate(prafeb, gameObject.transform);
            effection.transform.localPosition = prafeb.transform.position;
            effection.transform.localScale = prafeb.transform.localScale;
            this.unit = unit;
            return true;
        }
    }

    public override void onRemove()
    {
        ((BasicControler)unit).data.Now_Armor -= number;
        Destroy(effection);
    }


}
