using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_movement {
    public enum state {unActive,Active,Finish}
    public enum move {SkillStart,SkillEnd,Anim,Effection,Missile,Number};
	// Use this for initialization
    public move order;
    public List<object> argList;
    public state nowState  = state.unActive;
    public stage_movement(move order, List<object> argList)
    {
        this.order = order;
        this.argList = argList;
    }
}

public class skill_movement:stage_movement
{
    protected comboControler user_before=null;
    protected List<comboControler> tragets_before = new List<comboControler>();
    public comboControler user;
    public List<comboControler> tragets;
    public bool isTrigger=false;
    public skill_movement(move order, List<object> argList, unitControler user, List<unitControler> tragetlist,unitControler user_bef,List<unitControler> tragets_bef)
        : base(order, argList)
    {
        this.user_before = (comboControler)user_bef;
        if (tragets_bef == null)
        {
            tragets_before = null;
        }
        else
        {
            foreach (comboControler traget in tragets_bef)
            {
                tragets_before.Add(traget);
            }
        }
        this.user = (comboControler)user;
        if (tragetlist == null)
        {
            tragets = null;
        }
        else
        {
            foreach (comboControler traget in tragetlist)
            {
                tragets.Add(traget);
            }
        }
    }
}
