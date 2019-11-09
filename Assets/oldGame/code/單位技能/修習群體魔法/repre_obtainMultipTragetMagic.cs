using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_obtainMultipTragetMagic :randomRepre
{
    public override string Explanation
    {
        get
        {
            return "隨機學習一個群體目標的魔法師魔法";
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
            return "修習群體魔法";
        }
    }

    public override List<int> subsNos
    {
        get
        {
            return SkillList.main.multipTragetMagicNo;
        }
    }

    public override void init(unitData nowdata)
    {
        
    }
}