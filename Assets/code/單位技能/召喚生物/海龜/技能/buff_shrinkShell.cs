using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_shrinkShell : buff_shieldTemplate
{

    public override GameObject effection_prefab
    {
        get {
            return objectList.main.prafebList[32];
        }
    }
    protected override void beforeDamage(Damage income)
    {

    }
    public override float Duration
    {
        get
        {
            return 0;
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
            ((BasicControler)unit).state.CanAttack = false;
            ((BasicControler)unit).state.CanSkill = false;

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
            if (((buff_shrinkShell)Repetitive[0]).TimeLeft < (float)args["time"])
            {
                ((buff_shrinkShell)Repetitive[0]).timeLeft = (float)args["time"];
            }
            if (((buff_shrinkShell)Repetitive[0]).shieldNum < (int)args["num"])
            {
                ((buff_shrinkShell)Repetitive[0]).shieldNum = (int)args["num"];
            }
            return false;
        }

    }

    public override void onRemove()
    {
        //Debug.LogWarning("flame shield onRemove!!!");
        ((BasicControler)unit).state.CanAttack = true;
        ((BasicControler)unit).state.CanSkill = true;
        if (effection_prefab != null)
            Destroy(effection);
        ((BasicControler)unit)._befTakeDamage -= beforeTakeDamage;
    }
}
