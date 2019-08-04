using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_heavySkin : Buff
{
    protected int number;
    public override float Duration
    {
        get
        {
            return 0;
        }
    }

    public override bool onInit(unitControler unit, Buff[] Repetitive, Dictionary<string, object> args)
    {
        int num = (int)args["num"];
        float time = (float)args["time"];
        if (Repetitive.Length > 0)
        {
            buff_ArmorBreak buff = (buff_ArmorBreak)Repetitive[0];
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
            ((BasicControler)unit).data.Now_Armor += num;
            ((BasicControler)unit).data.Now_Mag_Resistance += num;
            number = num;
            GameObject prafeb = objectList.main.prafebList[8];
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
        ((BasicControler)unit).data.Now_Mag_Resistance -= number;
        Destroy(effection);
    }
}
