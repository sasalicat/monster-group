using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_obtainSingleTragetMagic : randomRepre
{
    public override string Explanation
    {
        get
        {
            return "隨機學習一個單體目標的魔法師魔法";
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
            return "修習單體魔法";
        }
    }

    public override List<int> subsNos
    {
        get
        {
            return SkillList.main.singleTragetMagicNo;
        }
    }

    public override void init(unitData nowdata)
    {
        
    }
}
