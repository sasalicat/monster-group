using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_1_baseAttackTragetting : modifier
{
    float percentage = 1f;
    public void befSkill(SkillInf skillInf, Dictionary<string, object> skillArgs, ref unitControler[] tragets)
    {
        if (skillInf.attack && ((comboControler.bonus_kind)skillArgs["bonus"]) == comboControler.bonus_kind.NoBonus)
        {
            if (((int)skillArgs["dice"]) <= percentage * 100f)
            {
                traget.trigger(skillArgs);
                if (skillArgs.ContainsKey("new_tragets")) {//技能如果欲修改目標數量,並不是直接改字典的值,那樣沒有用,只能通過給字典新增一個值,然後再由modifer來改ref tragets
                    tragets = (unitControler[])skillArgs["new_tragets"];//雖然做法很蠢,還是得向現實低頭
                }
            }
        }
    }
    public override void onSkillInit(unitControler owner, Callback4Unit_v2 deleg)
    {
        deleg._BefUseSkill += befSkill;
    }
    public mod_1_baseAttackTragetting(float percentage)
    {
        this.percentage = percentage;
    }
}
