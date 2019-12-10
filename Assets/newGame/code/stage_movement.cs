using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_movement {
    public enum state {unActive,Active,Finish}
    public enum move {SkillStart,SkillEnd,Anim,Effection,Missile,Number,ReCloseUp,UnCloseUp,CloseUp,onStage,ToClose,ResetClose};
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
    public List<comboControler> nowDomain;
    public bool isTrigger=false;
    public bool Close=true;
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
public abstract class stage_action_withskp : stage_action
{
    public stage_action_withskp(move order, List<object> argList):base(order,argList)
    {
    }
    protected skillpackage skp;
    public override void onLoad(skillpackage skp)
    {
        this.skp = skp;
        base.onLoad(skp);
        skp.stage_conditions[stage].Add(this);
    }
    public void conditionNext()
    {
        skp.Next(this);
    }
}
public class closeUp_action : stage_action_withskp
{
    public  closeUp_action( List<object> argList)
        : base(move.CloseUp, argList)
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
        closeupStage.main.closeUp(kind,conditionNext);

    }
}
public class uncloseUp_action : stage_action_withskp
{
    public uncloseUp_action( List<object> argList)
        : base(move.UnCloseUp, argList)
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
        closeupStage.main.uncloseUp(conditionNext);

    }
}
public class recloseUp_action : stage_action_withskp
{
    public recloseUp_action( List<object> argList)
        : base(move.ReCloseUp, argList)
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
        closeupStage.main.recloseUp(kind, conditionNext);

    }
}
public class onstage_action : stage_action_withskp
{
    public onstage_action(List<object> list):
        base(move.onStage,list)
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
        unitControler mainRole = (unitControler)argList[0];
        List<unitControler> tragets= (List<unitControler>)argList[1];
        closeupStage.main.onStage(mainRole, tragets.ToArray());
        conditionNext();//因為onStage是立刻結束的過程所以直接在後面呼叫就行了

    }
}
public class animSkill_action : stage_action {
    public animSkill_action( List<object> argList)
        : base(move.Anim, argList)
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
public class animBenhit_action : stage_action_withskp
{

    public animBenhit_action( List<object> argList)
        : base(move.Anim, argList)
    {
        
    }
    public override int stage
    {
        get
        {
            return 3;
        }
    }
    public override void action(skillpackage skp)
    {
        comboControler control = (comboControler)argList[0]; 
        int code = (int)argList[1];
        if (code != roleAnim.BEHIT)
        {
            Debug.Log("animBenhit_action code錯誤,code:"+code);
        }
        else
        {
            control.GetComponent<roleAnim>().anim_behit(conditionNext);
        }

    }
}
public class toClosePos_action : stage_action_withskp
{
    protected GameObject roleObj;
    public toClosePos_action(List<object> argList):base(move.ToClose,argList)
    {

    }
    public override int stage
    {
        get
        {
            return 0;
        }
    }
    public void ontime(float time)
    {
        Vector3 pos= closeupStage.main.nowClosePos.moveStep(time);
        roleObj.transform.position = pos;
        if (closeupStage.main.nowClosePos.end)
        {
            conditionNext();
            closeupStage.main.onUpdateFunc -= ontime;
        }
    }
    public override void action(skillpackage skp)
    {
        unitControler role = (unitControler)argList[0];
        Vector3 tragetPos = (Vector3)argList[1];
        Vector3 oriPos = (Vector3)argList[2];
        float time = (float)argList[3];
        roleObj = ((BasicControler)role).gameObject;
        if (closeupStage.main.nowClosePos.end)
        {
            closeupStage.main.nowClosePos.resetRole();
            closeupStage.main.nowClosePos = new closeAndPos(role,oriPos,tragetPos,time);
            closeupStage.main.onUpdateFunc += ontime;
        }
    }
}
public class resetClosePos_action : stage_action
{

    public resetClosePos_action(List<object> argList)
        : base(move.Anim, argList)
    {
        
    }
    public override int stage
    {
        get
        {
            return 4;
        }
    }
    public override void action(skillpackage skp)
    {
            closeupStage.main.nowClosePos.resetRole();
    }
}

