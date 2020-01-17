using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_1_baseAttackTragetting : modifier
{
    public void befSkill(SkillInf skillInf, Dictionary<string, object> skillArgs, ref unitControler[] tragets)
    {
        unitControler[] enemys = ((comboManager)comboManager.main).ChessBoard.enemyOf(traget.Owner);
        if (enemys.Length <= tragets.Length)
        {

        }
        else
        {
            List<unitControler> candidate = new List<unitControler>();
            foreach(unitControler unit in enemys)
            {
                bool found = false;
                foreach(unitControler traget in tragets)
                {
                    if(traget == unit)
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
            if (candidate.Count <= 0) {
                return;
            }
            int num= Randomer.main.getInt();
            int index = num % candidate.Count;
            comboControler newTraget = (comboControler)candidate[index];
            newTraget._beAppoint(traget.information, skillArgs);
            List<unitControler> newTragets = new List<unitControler>(tragets);
            newTragets.Add(newTraget);
            tragets = newTragets.ToArray();
        }
    }
    public override void onSkillInit(unitControler owner, Callback4Unit_v2 deleg)
    {
        deleg._BefUseSkill += befSkill;
    }
}
