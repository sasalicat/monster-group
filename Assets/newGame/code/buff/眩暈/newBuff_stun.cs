using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newBuff_stun : Buff_v2
{
    protected GameObject effection;
    public override float Duration
    {
        get
        {
            return 0;
        }
    }

    public override bool onInit(unitControler unit, Buff[] Repetitive, Dictionary<string, object> args)
    {
        //Debug.Log("總共有" + Repetitive.Length + "個重複Buff");
        if (Repetitive.Length == 0)
        {
            timeLeft = (float)args["time"];

            this.unit = (BasicControler)unit;
            ((comboControler)this.unit).state.CanAttack = false;
            ((comboControler)this.unit).state.CanSkill = false;
            string effkey = GetInstanceID() + "_1";
            Dictionary<string, object> eff_args = new Dictionary<string, object>();
            eff_args["traget"] = gameObject;
            //closeupStage.main.createEffect(dynamicSkill.resourcePool[prafebNames[0]], eff_args, effkey);
            closeupStage.main.display_effect(dynamicSkill.resourcePool[prafebNames[0]],eff_args,effkey);
            return true;

        }
        else
        {
            if (((newBuff_stun)Repetitive[0]).TimeLeft < (float)args["time"])
            {
                ((newBuff_stun)Repetitive[0]).timeLeft = (float)args["time"];
            }
            return false;
        }

    }

    public override void onRemove()
    {

        ((comboControler)unit).state.CanSkill = true;
        ((comboControler)unit).state.CanAttack = true;
        if (deleteByDispel)
        {
            closeupStage.main.display_swtichEffectOff(GetInstanceID() + "_1");
        }
        else
        {
            closeupStage.main.display_extraStart();
            closeupStage.main.display_swtichEffectOff(GetInstanceID() + "_1");
            closeupStage.main.display_extraEnd();
        }
    }
}
