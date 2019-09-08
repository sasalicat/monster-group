using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_obtainHolySupportMagic : randomRepre
{
    public override string Explanation
    {
        get
        {
            return "獲得本技能時,將本技能替換成一個隨機輔助型圣系魔法";
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
            return "修習輔助圣系魔法";
        }
    }

    public override List<int> subsNos
    {
        get
        {
            return SkillList.main.holySupportMagicNos;
        }
    }

    public override void init(unitData nowdata)
    {

    }
}
