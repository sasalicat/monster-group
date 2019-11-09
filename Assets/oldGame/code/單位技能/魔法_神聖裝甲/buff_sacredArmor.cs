using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_sacredArmor : Buff
{
    public override int kind
    {
        get
        {
            return POSITIVE;
        }
    }
    protected int number;
    protected int r_number;
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
        int num = (int)args["armor"];
        int recover = (int)args["heal"];
        float time = (float)args["time"];
        if (Repetitive.Length > 0)
        {
            buff_sacredArmor buff = (buff_sacredArmor)Repetitive[0];
            if (buff.number < num)
            {
                ((BasicControler)unit).data.Now_Armor += (num-buff.number);
                buff.number = num;
            }
            if (buff.r_number < recover)
            {
                ((BasicControler)unit).data.Now_Life_Recover += (num - buff.r_number);
                buff.r_number = recover;
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
            number = num;
            ((BasicControler)unit).data.Now_Life_Recover += recover;
            r_number = recover;
            GameObject prafeb = objectList.main.prafebList[40];
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
        ((BasicControler)unit).data.Now_Life_Recover -= r_number;
        Destroy(effection);
    }
}

