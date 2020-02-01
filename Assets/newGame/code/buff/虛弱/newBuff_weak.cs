using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newBuff_weak : Buff_v2
{
    protected int layer=0;
    protected GameObject effection;
    public override float Duration
    {
        get
        {
            return 0;
        }
    }
    public void befCauseDamage_cb(Damage d)
    {
        float percent = 0f;
        if (layer >= 0 && layer <= 10)
        {
            percent= (float)(10 - layer) / 10f;
        }
        d.num = (int)(d.num * percent);
    }
    public override bool onInit(unitControler unit, Buff[] Repetitive, Dictionary<string, object> args)
    {
        //Debug.Log("總共有" + Repetitive.Length + "個重複Buff");
        int now_layer = (int)args["layer"];
        if (Repetitive.Length == 0)
        {
            timeLeft = (float)args["time"];

            this.unit = (BasicControler)unit;
            string effkey = GetInstanceID() + "_1";
            Dictionary<string, object> eff_args = new Dictionary<string, object>();
            eff_args["traget"] = gameObject;
            //closeupStage.main.createEffect(dynamicSkill.resourcePool[prafebNames[0]], eff_args, effkey);
            closeupStage.main.display_effect(dynamicSkill.resourcePool[prafebNames[0]], eff_args, effkey);
            ((comboControler)unit)._befCauseDamage += befCauseDamage_cb;
            layer = now_layer;
            return true;

        }
        else
        {
            if (((newBuff_weak)Repetitive[0]).TimeLeft < (float)args["time"])
            {
                ((newBuff_weak)Repetitive[0]).timeLeft = (float)args["time"];
            }
            if (((newBuff_weak)Repetitive[0]).layer < now_layer)
            {
                ((newBuff_weak)Repetitive[0]).layer = now_layer;
            }
            return false;
        }

    }

    public override void onRemove()
    {
        if (deleteByDispel)//驅散
        {
            closeupStage.main.display_swtichEffectOff(GetInstanceID() + "_1");
            ((comboControler)unit)._befCauseDamage -= befCauseDamage_cb;
        }
        else
        {
            closeupStage.main.display_extraStart();
            closeupStage.main.display_swtichEffectOff(GetInstanceID() + "_1");
            closeupStage.main.display_extraEnd();
            ((comboControler)unit)._befCauseDamage -= befCauseDamage_cb;
        }
    }
}

