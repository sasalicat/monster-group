using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_burn : Buff {
    public int layer;
    public const int DAMAGE_PER_LAYER =5;
    protected BasicControler unit;
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
            timeLeft = (float)args["time"];
            this.unit = (BasicControler)unit;


            GameObject prefab = objectList.main.prafebList[15];
            effection = Instantiate(prefab, this.unit.transform);
            effection.transform.localPosition = prefab.transform.position;
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
                timeLeft = (float)args["time"];
                this.unit = (BasicControler)unit;


                GameObject prefab = objectList.main.prafebList[15];
                effection = Instantiate(prefab, this.unit.transform);
                effection.transform.localPosition = prefab.transform.position;
                return true;
            }
            
        }

    }
    public override void onIntarvel(unitControler unit, float timeBetween)
    {
        unit.takeDamage(new Damage(layer * DAMAGE_PER_LAYER, Damage.KIND_MAGICAL, creater));
        base.onIntarvel(unit, timeBetween);
       
    }
    public override void onRemove()
    {
        Destroy(effection);
    }
}
