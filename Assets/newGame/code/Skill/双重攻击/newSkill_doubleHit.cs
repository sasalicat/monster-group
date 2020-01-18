using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSkill_doubleHit : dynamicSkill {
    public override float StandCoolDown
    {
        get
        {
            return -1;
        }
    }

    public override bool canUse
    {
        get
        {
            return false;
        }
    }

    public override unitControler[] getTragets(Environment env)
    {
        return null;
    }

    public override SkillInf Inf()
    {
        return new SkillInf_v2(this);
    }

    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];
        unitControler[] enemys = ((comboManager)comboManager.main).ChessBoard.enemyOf(Owner);
        if (enemys.Length <= tragets.Length)
        {

        }
        else
        {
            args["phy_damage_multiple"] = ((float)args["phy_damage_multiple"]) - 0.25f;
            List<unitControler> candidate = new List<unitControler>();
            foreach (unitControler unit in enemys)
            {
                bool found = false;
                foreach (unitControler traget in tragets)
                {
                    if (traget == unit)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)//如果敌人不在目标中
                {
                    candidate.Add(unit);
                }
            }
            if (candidate.Count <= 0)
            {
                return;
            }
            int num = Randomer.main.getInt();
            int index = num % candidate.Count;
            comboControler newTraget = (comboControler)candidate[index];
            //newTraget._beAppoint(information, args);
            List<unitControler> newTragets = new List<unitControler>(tragets);
            newTragets.Add(newTraget);
            tragets = newTragets.ToArray();
            args["new_tragets"] = tragets;//向現實妥協的方法,在這裡無論如何都修改不了ref tragets,mod會在外部閱讀然後修改的ref tragets
        }
    }
}
