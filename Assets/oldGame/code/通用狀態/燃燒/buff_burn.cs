using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_burn : Buff {
    public int layer;
    public const int DAMAGE_PER_LAYER =5;
    //protected BasicControler unit;
    protected GameObject effection;
    protected BasicControler creater;
    public readonly float TriggerCycle = unitData.STAND_ATK_INTERVAL;
    public float trigger_time_left;
    public override float Duration
    {
        get
        {
            return 0;
        }
    }
    private void befHeal(HealMsg msg)
    {
        msg.num = (int)(msg.num * 0.5f);
    }
    public override bool onInit(unitControler unit, Buff[] Repetitive, Dictionary<string, object> args)
    {
        int selfLayer = (int)args["layer"];
        //Debug.Log("總共有" + Repetitive.Length + "個重複Buff");
        creater = (BasicControler)args["creater"];
        if (Repetitive.Length == 0)
        {

            layer = selfLayer;
            trigger_time_left = TriggerCycle;
            timeLeft = (float)args["time"];
            this.unit = (BasicControler)unit;

            ((BasicControler)unit)._befHealing += befHeal;
            GameObject prefab = objectList.main.prafebList[15];
            effection = Instantiate(prefab, ((BasicControler)this.unit).transform);
            effection.transform.localPosition = new Vector2(0,-0.67f);
            return true;

        }
        else
        {
            buff_burn before = ((buff_burn)Repetitive[0]);
            if (before.layer > selfLayer)//之前的燃燒層數比較高
            {
                return false;
            }
            else if (before.layer == selfLayer)
            {
                if (before.TimeLeft < (float)args["time"])
                {
                    before.timeLeft = (float)args["time"];
                    return false;
                }
                else {
                    return false;
                }
            }
            else
            {
                before.deleteSelf();

                layer = selfLayer;
                trigger_time_left = TriggerCycle;
                timeLeft = (float)args["time"];
                this.unit = (BasicControler)unit;

                ((BasicControler)unit)._befHealing += befHeal;
                GameObject prefab = objectList.main.prafebList[15];
                effection = Instantiate(prefab, ((BasicControler)this.unit).transform);
                effection.transform.localPosition = new Vector2(0, -0.67f);
                return true;
            }
            
        }

    }
    public override void onIntarvel(unitControler unit, float timeBetween)
    {
        Debug.Log("burn onIntarvel 被呼叫 time left:"+ trigger_time_left);
        trigger_time_left -= timeBetween;
        if (trigger_time_left <= 0)
        {
            Debug.Log("trigger_time_left 小於等於0 unit 名字:"+((BasicControler)unit).gameObject.name+" layer:"+layer);
            this.unit.takeDamage(new Damage(layer * DAMAGE_PER_LAYER, Damage.KIND_MAGICAL, creater));
            trigger_time_left = TriggerCycle;
        }
        base.onIntarvel(unit, timeBetween);
       
    }
    public override void onRemove()
    {
        Destroy(effection);
    }
}
