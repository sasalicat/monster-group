using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newBuff_blind : Buff_v2 {
    

    public override float Duration
    {
        get
        {
            return 0;
        }
    }

    public void befSkill(SkillInf skillInf, Dictionary<string, object> skillArgs, ref unitControler[] tragets)
    {
        int dice = (int)skillArgs["dice"];
        if (dice < 50)
        {
            foreach (comboControler traget in tragets)
            {
                if (traget.playerNo != ((comboControler)unit).playerNo)
                {
                    if (!((Dictionary<comboControler, bool>)skillArgs["miss"])[traget])
                    {
                        ((Dictionary<comboControler, bool>)skillArgs["miss"])[traget] = true;
                        closeupStage.main.display_anim(traget, AnimCodes.DODGE);
                        closeupStage.main.display_floatingText(traget, TextCreater.DODGE);
                    }
                }
            }
        }
    }

    public override bool onInit(unitControler unit, Buff[] Repetitive, Dictionary<string, object> args)
    {
        if (Repetitive.Length == 0)
        {
            timeLeft = (float)args["time"];
            this.unit = (BasicControler)unit;
            ((comboControler)unit)._befUseSkill += befSkill;
            string effkey = GetInstanceID() + "_1";
            Dictionary<string, object> eff_args = new Dictionary<string, object>();
            eff_args["traget"] = gameObject;
            //Debug.Log("特效物件名稱:"+ prafebNames[0]);
            closeupStage.main.display_effect(dynamicSkill.resourcePool[prafebNames[0]], eff_args, effkey);
            return true;

        }
        else
        {
            if (((newBuff_blind)Repetitive[0]).TimeLeft < (float)args["time"])
            {
                ((newBuff_blind)Repetitive[0]).timeLeft = (float)args["time"];
            }
            return false;
        }
    }

    public override void onRemove()
    {
        ((comboControler)unit)._befUseSkill -= befSkill;
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
