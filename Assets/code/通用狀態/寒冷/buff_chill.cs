using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_chill : Buff {
    public int layer;
    public const int ATK_SLOW_PER_LAYER = 50;
    public const int SKILL_SLOW_PER_LAYER = 50;
    //protected BasicControler unit;
    protected GameObject effection;
    protected BasicControler creater;

    public override float Duration
    {
        get
        {
            return 0;
        }
    }

    public override bool onInit(unitControler unit, Buff[] Repetitive, Dictionary<string, object> args)
    {
        int selfLayer = (int)args["layer"];
        //Debug.Log("總共有" + Repetitive.Length + "個重複Buff");
        creater = (BasicControler)args["creater"];
        if (Repetitive.Length == 0)
        {

            layer = selfLayer;

            timeLeft = (float)args["time"];
            this.unit = (BasicControler)unit;
            ((BasicControler)unit).data.Now_Attack_Speed -= layer * ATK_SLOW_PER_LAYER;
            ((BasicControler)unit).data.Now_Cooldown_Reinforce -= layer * SKILL_SLOW_PER_LAYER;

            GameObject prefab = objectList.main.prafebList[26];
            effection = Instantiate(prefab, ((BasicControler)this.unit).transform);
            effection.transform.localPosition = prefab.transform.position;
            return true;

        }
        else
        {
            buff_chill before = ((buff_chill)Repetitive[0]);
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
                else
                {
                    return false;
                }
            }
            else
            {
                before.deleteSelf();

                layer = selfLayer;

                timeLeft = (float)args["time"];
                this.unit = (BasicControler)unit;
                ((BasicControler)unit).data.Now_Attack_Speed -= layer * ATK_SLOW_PER_LAYER;
                ((BasicControler)unit).data.Now_Cooldown_Reinforce -= layer * SKILL_SLOW_PER_LAYER;

                GameObject prefab = objectList.main.prafebList[25];
                effection = Instantiate(prefab, ((BasicControler)this.unit).transform);
                effection.transform.localPosition = prefab.transform.position;
                return true;
            }

        }

    }
    public override void onRemove()
    {
        ((BasicControler)unit).data.Now_Attack_Speed += layer * ATK_SLOW_PER_LAYER;
        ((BasicControler)unit).data.Now_Cooldown_Reinforce += layer * SKILL_SLOW_PER_LAYER;
        Destroy(effection);
    }
}
