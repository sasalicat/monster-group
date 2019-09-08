using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_obtainHolyHealingMagic : randomRepre {

    public override string Explanation
    {
        get
        {
            return "獲得本技能時,將本技能替換成一個隨機治疗型圣系魔法";
        }
    }

    public override string ScriptName
    {
        get
        {
            return null;
        }
    }

    public override string SkillName
    {
        get
        {
            return "修習治疗圣系魔法";
        }
    }

    public override List<int> subsNos
    {
        get
        {
            return SkillList.main.holyHealingMagicNos;
        }
    }

    public override void init(unitData nowdata)
    {

    }
}
