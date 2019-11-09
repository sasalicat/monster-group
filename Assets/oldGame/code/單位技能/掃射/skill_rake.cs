using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_rake : CDSkill
{
    protected bool active;
    protected GameObject effection;
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0&& owner.state.CanSkill;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return 3.5f * unitData.STAND_ATK_INTERVAL;
        }
    }
    public void befSkill(SkillInf skillInf, Dictionary<string, object> skillArgs,ref unitControler[] tragets)
    {
        if (active&&skillInf.attack)
        {
            //Debug.LogWarning("active 設成false");
            active = false;
            ChessBoard env = (ChessBoard)owner.env;
            List<BasicControler> newTragets =new List<BasicControler>();
            foreach(BasicControler traget in tragets)//先加入原本的目標
            {
                newTragets.Add(traget);
            }
            if (owner.playerNo % 2 == 1)
            {
                for(int x = 0; x < env.X; x++)
                {
                    for(int y = env.Y / 2 - 1; y >= 0; y--)
                    {
                        if (env.board[y, x] != null)
                        {
                            if (!newTragets.Contains((BasicControler)env.board[y, x]))
                            {
                                newTragets.Add((BasicControler)env.board[y, x]);
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int x = 0; x < env.X; x++)
                {
                    //Debug.LogWarning("skill_rake x:" + x);
                    for (int y = env.Y / 2 ; y <env.Y; y++)
                    {
                        if (env.board[y, x] != null)
                        {
                            if (!newTragets.Contains((BasicControler)env.board[y, x]))
                            {
                                //Debug.LogWarning("y=" + y + "加入" + ((BasicControler)env.board[y, x]).gameObject.name);
                                newTragets.Add((BasicControler)env.board[y, x]);
                            }
                            break;
                        }
                    }
                }
            }
            if (effection != null)
            {
                Destroy(effection);
            }
            //Debug.LogWarning("改為新的" + newTragets.Count + "個目標");
            tragets= newTragets.ToArray();
        }
    }
    public override unitControler[] findTraget(Environment env)
    {
        return new unitControler[1] { owner };
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(true, true, false, new List<string>() { SkillInf.TAG_DAMAGE });
        ((BasicControler)owner)._befUseSkill += befSkill;
    }

    public override void trigger(Dictionary<string, object> args)
    {
        if (!active) {
            //Debug.LogWarning("掃射-創建effection active:"+active);
            active = true;
            GameObject prafeb = objectList.main.prafebList[36];
            if (effection == null)
            {
                effection = Instantiate(prafeb, owner.transform);
                effection.transform.localPosition = prafeb.transform.position;
            }
        }
        setTime(args);
    }
}
