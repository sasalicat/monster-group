using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_slowHealing : CDSkill {
    public const int HEALING_SECOND= 5;
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
            return 4f * unitData.STAND_ATK_INTERVAL;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        unitControler[] team= ((ChessBoard)env).teammateOf(owner);
        List<BasicControler> tragets = new List<BasicControler>();
        if (team.Length > 0)
        {
            foreach (BasicControler unit in team)
            {
                if ((float)unit.data.Now_Life / (float)unit.data.Now_Max_Life <= 0.6f) {
                    tragets.Add(unit);
                }
            }
            if (tragets.Count == 0)
            {
                BasicControler min = (BasicControler)team[0];
                for (int i=1;i<team.Length;i++) {
                    BasicControler unit = (BasicControler)team[i];
                    if ((float)unit.data.Now_Life / (float)unit.data.Now_Max_Life < (float)unit.data.Now_Life / (float)unit.data.Now_Max_Life)
                    {
                        min = unit;
                    }
                }
                tragets.Add(min);

            }
        }
        return tragets.ToArray();
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(false, true, false, new List<string>() { SkillInf.TAG_CURE,SkillInf.TAG_BUFF,SkillInf.TAG_HOLY});

    }

    public override void trigger(Dictionary<string, object> args)
    {
        unitControler[] tragets = (unitControler[])args["tragets"];
        if (!(bool)args["miss"])
        {
            foreach (BasicControler traget in tragets) {
                Dictionary<string, object> buff_arg = new Dictionary<string, object>();
                buff_arg["num"] = (int)(HEALING_SECOND * ((BasicControler)owner).data.Now_Mag_Multiple);
                //Debug.LogWarning("arg[num]設置為:" + buff_arg["num"]);
                buff_arg["time"] = 2 * unitData.STAND_ATK_INTERVAL;
                buff_arg["creater"] = owner;
                traget.addBuff("buff_slowHealing", buff_arg);
            }
        }
        setTime(args);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
