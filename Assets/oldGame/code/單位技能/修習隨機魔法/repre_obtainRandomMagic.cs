using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_obtainRandomMagic : randomRepre
{
    public override string Explanation
    {
        get
        {
            return "隨機學習一個魔法師魔法";
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
            return "修習隨機魔法";
        }
    }

    public override List<int> subsNos
    {
        get
        {
            return SkillList.main.MagicNos;
        }
    }

    public override void init(unitData nowdata)
    {

    }
}