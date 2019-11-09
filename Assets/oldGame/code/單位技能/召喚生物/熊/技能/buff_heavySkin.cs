using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_heavySkin : Buff
{
    protected int number;
    private GameObject effection;
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
            buff_heavySkin buff = (buff_heavySkin)Repetitive[0];
            if (buff.number < num)
            {
                ((BasicControler)unit).data.Now_Armor += (num - buff.number);
                ((BasicControler)unit).data.Now_Mag_Resistance += (num - buff.number);
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
            GameObject prafeb = objectList.main.prafebList[31];
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
