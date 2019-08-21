using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_powerBless : CDSkill
{
    protected const int POWER_NUMBER = 5;
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0 && owner.state.CanSkill && owner.traget != null;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return 4 * unitData.STAND_ATK_INTERVAL;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        unitControler[] front = ((ChessBoard)env).frontRowFor(owner);
        if (front != null && front.Length > 0)
        {
            foreach (unitControler unit in front)//優先找和自己col值一樣的單位
            {
                if (((ChessBoard)env).getPosFor(unit)[0] == ((ChessBoard)env).getPosFor(owner)[0])
                {
                    return new unitControler[] { unit };
                }
            }
            int index = Randomer.main.getInt() % front.Length;
            return new unitControler[] { front[index] };
        }
        return null;
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(true, true, false, new List<string>() { SkillInf.TAG_BUFF });

    }

    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];
        if (tragets == null)
        {
            return;
        }
        foreach (unitControler traget in tragets)
        {
            BasicControler nowTraget = (BasicControler)traget;
            Dictionary<string, object> buff_arg = new Dictionary<string, object>();
            buff_arg["power"] = (int)(POWER_NUMBER * ((BasicControler)owner).data.Now_Mag_Multiple);
            //Debug.LogWarning("arg[num]設置為:" + buff_arg["num"]);
            buff_arg["time"] = 6 * unitData.STAND_ATK_INTERVAL;
            buff_arg["creater"] = owner;
            nowTraget.addBuff("buff_powerBless", buff_arg);
            //Debug.LogWarning("加上buff_flameShield");

        }
        setTime();
    }
}
