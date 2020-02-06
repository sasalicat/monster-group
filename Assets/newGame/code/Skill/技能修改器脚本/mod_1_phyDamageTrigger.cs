using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_1_phyDamageTrigger : modifier
{
    int now_jcId = -1;
    float percentage = 0;
    public void aftCauseDamage(Damage d)
    {
        Damage_v2 d_v2 = (Damage_v2)d;
        if (!d_v2.extraArgs.ContainsKey("jcId"))//沒有jcId的傷害說明是由buff觸發的持續傷害,不能觸發技能
        {
            return;
        }
        if (d.kind ==Damage.KIND_PHYSICAL &&((int)d_v2.extraArgs["dice"]) <= percentage * 100f && now_jcId != ((int)d_v2.extraArgs["jcId"]))
        {
            Dictionary<string, object> args= new Dictionary<string, object>();
            args["damage"] = d;
            args["traget"] = d.creater;
            traget.trigger(args);
        }
    }
    public override void onSkillInit(unitControler owner, Callback4Unit_v2 deleg)
    {
        deleg._AftCauseDamage += aftCauseDamage;
    }
    public mod_1_phyDamageTrigger(float percentage)
    {
        this.percentage = percentage;
    }

}
