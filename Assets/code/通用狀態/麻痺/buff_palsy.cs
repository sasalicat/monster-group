using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_palsy : Buff {
    public int layer;
    public const int DAMAGE_PER_LAYER = 5;
    //protected BasicControler unit;
    protected GameObject effection;
    protected BasicControler creater;
    public readonly float TriggerCycle = unitData.STAND_ATK_INTERVAL;
    public override float Duration
    {
        get
        {
            return 0;
        }
    }
    public void aftRoleSkill(SkillInf skillInf, Dictionary<string, object> skillArgs, unitControler[] tragets) {
        if (skillInf.activeSkill)
        {
            unit.takeDamage(new Damage((int)(layer * DAMAGE_PER_LAYER * creater.data.Now_Mag_Multiple),
                Damage.KIND_MAGICAL, creater,
                new List<string>() {Damage.TAG_THUNDER}));
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

            ((BasicControler)unit)._aftUseSkill += aftRoleSkill;
            GameObject prefab = objectList.main.prafebList[21];
            effection = Instantiate(prefab, ((BasicControler)this.unit).transform);
            effection.transform.localPosition = new Vector2(0, 0);
            return true;

        }
        else
        {
            buff_palsy before = ((buff_palsy)Repetitive[0]);
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

                ((BasicControler)unit)._aftUseSkill += aftRoleSkill;
                GameObject prefab = objectList.main.prafebList[15];
                effection = Instantiate(prefab, ((BasicControler)this.unit).transform);
                effection.transform.localPosition = new Vector2(0, -0.67f);
                return true;
            }

        }

    }
    public override void onRemove()
    {
        Destroy(effection);
    }
}
