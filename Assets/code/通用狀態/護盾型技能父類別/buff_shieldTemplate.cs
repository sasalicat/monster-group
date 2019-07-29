using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class buff_shieldTemplate : Buff {

    protected GameObject effection;
    protected BasicControler creater;
    public int shieldNum;
    public abstract GameObject effection_prefab
    {
        get;   
    }
    protected abstract void beforeDamage(Damage income);
    public override float Duration
    {
        get
        {
            return 0;
        }
    }
    public void beforeTakeDamage(Damage d)
    {
        beforeDamage(d);
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


            GameObject prefab = effection_prefab;
            if (prefab != null)
            {
                effection = Instantiate(prefab, ((BasicControler)this.unit).transform);
                effection.transform.localPosition = prefab.transform.position;
            }
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

    public override void onRemove()
    {
        //Debug.LogWarning("flame shield onRemove!!!");
        if(effection_prefab!=null)
            Destroy(effection);
        ((BasicControler)unit)._befTakeDamage -= beforeTakeDamage;
    }
}
