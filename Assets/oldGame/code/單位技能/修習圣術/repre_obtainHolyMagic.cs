using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_obtainHolyMagic : randomRepre
{


    public override string Explanation
    {
        get
        {
            return "獲得本技能時,將本技能替換成一個隨機圣系魔法";
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
            return "修習圣系魔法";
        }
    }

    public override List<int> subsNos
    {
        get
        {
            return SkillList.main.holyMagicNos;
        }
    }

    public override void init(unitData nowdata)
    {
        
    }


}
