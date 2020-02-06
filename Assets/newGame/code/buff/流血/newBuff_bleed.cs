using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newBuff_bleed : Buff_v2
{
    protected int totalDamage = 0;
    protected int damageOnce = 0;
    protected const float damageInterval = 50f;
    protected float nextDamageTime = damageInterval;
    protected GameObject effection;
    public override int kind
    {
        get
        {
            return Buff.NEGATIVE;
        }
    }
    public override float Duration
    {
        get
        {
            return 0;
        }
    }
    public override void onIntarvel(unitControler unit, float timeBetween)
    {
        base.onIntarvel(unit, timeBetween);
        nextDamageTime -= timeBetween;
        if (nextDamageTime <= 0)
        {
            totalDamage -= damageOnce;
            Damage_v2 d = new Damage_v2(damageOnce, Damage.KIND_PHYSICAL, null);
            d.extraArgs["critical"] = false;
            closeupStage.main.display_extraStart();
            closeupStage.main.display_anim(unit, AnimCodes.BEHIT);
            unit.takeDamage(d);
            closeupStage.main.display_extraEnd();
            nextDamageTime = damageInterval;
        }

        

    }
    public override bool onInit(unitControler unit, Buff[] Repetitive, Dictionary<string, object> args)
    {
        //Debug.Log("總共有" + Repetitive.Length + "個重複Buff");
        int total_damage = (int)args["totalNum"];
        if (Repetitive.Length == 0)
        {
            timeLeft = (float)args["time"];
            totalDamage = total_damage;
            int triggerTime = (int)TimeLeft / (int)damageInterval; 
            damageOnce = total_damage /triggerTime;

            this.unit = (BasicControler)unit;
            string effkey = GetInstanceID() + "_1";
            Dictionary<string, object> eff_args = new Dictionary<string, object>();
            eff_args["traget"] = gameObject;
            closeupStage.main.display_effect(dynamicSkill.resourcePool[prafebNames[0]], eff_args, effkey);

            return true;

        }
        else
        {
            newBuff_bleed oldOne = ((newBuff_bleed)Repetitive[0]);
            if (oldOne.totalDamage < total_damage)
            {
                if (oldOne.TimeLeft < (float)args["time"])
                {
                    oldOne.timeLeft = (float)args["time"];
                }

                int triggerTime = (int)oldOne.TimeLeft / (int)damageInterval;
                oldOne.totalDamage = total_damage;
                oldOne.damageOnce = oldOne.totalDamage / triggerTime;
            }
            return false;
        }

    }

    public override void onRemove()
    {
        if (deleteByDispel)//驅散
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