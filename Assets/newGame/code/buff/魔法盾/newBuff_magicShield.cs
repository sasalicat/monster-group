using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newBuff_magicShield : Buff_v2
{
    protected int numLeft = 1;
    protected GameObject effection;
    public override int kind
    {
        get
        {
            return Buff.POSITIVE;
        }
    }
    public override float Duration
    {
        get
        {
            return 0;
        }
    }
    public void befTakeDamage(Damage d)
    {
        if (d.kind != Damage.KIND_REAL)//不能吸收真實傷害
        {
            if (d.num <= numLeft)
            {
                d.num = 0;
                numLeft -= d.num;
                closeupStage.main.display_msgToEffect(GetInstanceID() + "_1", "behit",null);
            }
            else
            {
                d.num -= numLeft;
                numLeft = 0;
                deleteSelf();//用驅散的原因是因為,由傷害造成的護盾消失都會發生在skillpackage或extraAcition里
            }
        }
    }
    public override bool onInit(unitControler unit, Buff[] Repetitive, Dictionary<string, object> args)
    {
        //Debug.Log("總共有" + Repetitive.Length + "個重複Buff");
        int num = (int)args["num"];
        if (Repetitive.Length == 0)
        {
            timeLeft = (float)args["time"];

            this.unit = (BasicControler)unit;
            string effkey = GetInstanceID() + "_1";
            Dictionary<string, object> eff_args = new Dictionary<string, object>();
            eff_args["traget"] = gameObject;
            //closeupStage.main.createEffect(dynamicSkill.resourcePool[prafebNames[0]], eff_args, effkey);
            closeupStage.main.display_effect(dynamicSkill.resourcePool[prafebNames[0]], eff_args, effkey);
            ((comboControler)unit)._befTakeDamage += befTakeDamage;
            numLeft = num;
            return true;

        }
        else
        {
            if (((newBuff_magicShield)Repetitive[0]).TimeLeft < (float)args["time"])
            {
                ((newBuff_magicShield)Repetitive[0]).timeLeft = (float)args["time"];
            }
            if (((newBuff_magicShield)Repetitive[0]).numLeft < num)
            {
                ((newBuff_magicShield)Repetitive[0]).numLeft = num;
            }
            return false;
        }

    }

    public override void onRemove()
    {
        if (deleteByDispel || numLeft ==0)//驅散或者護盾點數被耗盡
        {
            closeupStage.main.display_swtichEffectOff(GetInstanceID() + "_1");
            ((comboControler)unit)._befTakeDamage -= befTakeDamage;
        }
        else
        {
            closeupStage.main.display_extraStart();
            closeupStage.main.display_swtichEffectOff(GetInstanceID() + "_1");
            closeupStage.main.display_extraEnd();
            ((comboControler)unit)._befTakeDamage -= befTakeDamage;
        }
    }
}

