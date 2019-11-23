using System;
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
            tragets_before = new List<comboControler>();
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
            tragets = new List<comboControler>();
            foreach (comboControler traget in tragetlist)
            {
                tragets.Add(traget);
            }
        }
    }
}
public abstract class stage_action:stage_movement
{
    public stage_action(move order, List<object> argList):base(order,argList)
    {
    }
    public abstract int stage {
        get;
    }
    public virtual void onLoad(skillpackage skp) {
        skp.stage_funcs[stage] += action;
    }
    public abstract void action(skillpackage skp);
}
public class closeUp_action : stage_action
{
    public closeUp_action(move order, List<object> argList)
        : base(order, argList)
    {

    }
    public override int stage
    {
        get
        {
            return 0;
        }
    }

    public override void action(skillpackage skp)
    {
        int kind = (int)argList[0];
        closeupStage.main.closeUp(kind);

    }
}
public class animSkill_action : stage_action {
    public animSkill_action(move order, List<object> argList)
        : base(order, argList)
    {
        
    }
    public override int stage
    {
        get
        {
            return 1;
        }
    }
    public override void action(skillpackage skp) {
        comboControler control = (comboControler)argList[0]; 
        int code = (int)argList[1];
        if (code == roleAnim.ATTACK)
            control.GetComponent<roleAnim>().anim_attack(skp.Next);
        else if (code == roleAnim.MAGIC)
            control.GetComponent<roleAnim>().anim_magic(skp.Next);
        else
            Debug.LogError("animSkill_action code錯誤,不正確的code:" + code);
    }
}
public class animBenhit_action : stage_action
{
    public skillpackage skp;
    public animBenhit_action(move order, List<object> argList)
        : base(order, argList)
    {
        
    }
    public override int stage
    {
        get
        {
            return 3;
        }
    }
    public virtual void animEnd()
    {
        skp.Next(this);
    }
    public override void action(skillpackage skp)
    {
        this.skp=skp;
        comboControler control = (comboControler)argList[0]; 
        int code = (int)argList[1];
        skp.stage3_condition.Add(this);
        if (code != roleAnim.BEHIT)
        {
            Debug.Log("animBenhit_action code錯誤,code:"+code);
        }
        else
        {
            control.GetComponent<roleAnim>().anim_behit(animEnd);
        }

    }
}


