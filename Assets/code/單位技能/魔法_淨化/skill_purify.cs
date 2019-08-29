using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_purify : CDSkill
{
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0 && owner.traget != null && owner.state.CanSkill;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return unitData.STAND_ATK_INTERVAL*3;
        }
    }
    protected  float reuseTime= unitData.STAND_ATK_INTERVAL;
    public override unitControler[] findTraget(Environment env)
    {
       unitControler[] teammates=  ((ChessBoard)env).teammateOf(owner);
        BasicControler traget = (BasicControler)teammates[0];
        int traget_buff_num = 0;
        foreach (Buff b in traget.buffList)
        {
            int buff_num = 0;
            if (b.kind == Buff.NEGATIVE)
            {
                buff_num++;
            }
            traget_buff_num = buff_num;
        }
        for (int i=1;i<teammates.Length;i++)
        {
            foreach(Buff b in ((BasicControler)teammates[i]).buffList)
            {
                int buff_num = 0;
                if(b.kind == Buff.NEGATIVE)
                {
                    buff_num++;
                }
                if(buff_num > traget_buff_num)
                {
                    traget = (BasicControler)teammates[i];
                    traget_buff_num = buff_num;
                }
            }
        }
        ;
        if (traget_buff_num == 0)
        {
            return new unitControler[0];
        }
        else
        {
            return new unitControler[1] { traget };
        }

    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(false, true, false, new List<string>() { SkillInf.TAG_CURE });
    }

    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];
        if (tragets.Length>0)
        {
            if (!(bool)args["miss"])
            {
                foreach (BasicControler traget in tragets)
                {
                    GameObject eff= Instantiate(objectList.main.prafebList[44], traget.transform);
                    eff.transform.localPosition = objectList.main.prafebList[44].transform.position;
                    foreach (Buff buff in traget.buffList)
                    {
                        if (buff.kind == Buff.NEGATIVE)
                        {
                            buff.deleteSelf();
                        }
                    }
                }
            }
            setTime();
        }
        else
        {
            timeLeft = reuseTime;
        }
    }
}
