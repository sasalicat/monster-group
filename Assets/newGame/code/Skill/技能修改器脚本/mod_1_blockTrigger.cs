using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_1_blockTrigger : modifier
{
    float percentage = 0;
    int now_jcId = -1;
    public void aftBlock(Damage d)
    {
        Damage_v2 d_v2 = (Damage_v2)d;
        if (((int)d_v2.extraArgs["dice"]) <= percentage * 100f&&now_jcId!= ((int)d_v2.extraArgs["jcId"]))//每個判定鏈只能觸發一次
        {
            now_jcId = ((int)d_v2.extraArgs["jcId"]);//保存當前判定鏈id,這樣同個判定鏈下一次觸發aftBlock時就會因為jcId相等不進這裡
            ((dynamicSkill)traget).arouse2chain(((comboManager)comboManager.main).ChessBoard, ((int)d_v2.extraArgs["jcId"]));
            
        }
    }
    public override void onSkillInit(unitControler owner, Callback4Unit_v2 deleg)
    {
        deleg._aftBlock += aftBlock;
    }
    public mod_1_blockTrigger(float percentage)
    {
        this.percentage = percentage;
    }
}