﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_movement {
    public enum state {unActive,Active,Finish}
    public enum move {SkillStart,SkillEnd,Anim,Effection,Missile,Number,ReCloseUp,UnCloseUp,CloseUp,onStage,ToClose,ResetClose,hpChange,floatNum,ExtraStart,ExtraEnd,OffEffectByKey};
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
    public skill_movement( List<object> argList, unitControler user, List<unitControler> tragetlist,unitControler user_bef,List<unitControler> tragets_bef)
        : base(move.SkillStart, argList)
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
public class extraAction_movement : stage_movement
{
    public extraAction_movement(List<object> list):base(move.ExtraStart,list){
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
        skp.addFunc(stage, action);
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
        skp.addCondition(stage, this);
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
public class uncloseUp_action : stage_action
{
    public uncloseUp_action( List<object> argList)
        : base(move.UnCloseUp, argList)
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
        closeupStage.main.uncloseUp();

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
        if (code == AnimCodes.ATTACK)
            control.GetComponent<roleAnim>().anim_attack(skp.Next);
        else if (code == AnimCodes.MAGIC)
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
        if (code != AnimCodes.BEHIT)
        {
            Debug.Log("animBenhit_action code錯誤,code:"+code);
        }
        else
        {
            control.GetComponent<roleAnim>().anim_behit(conditionNext);
        }

    }
}
public class animDodge_action : stage_action_withskp
{
    public animDodge_action(List<object> argList):base(move.Anim,argList)
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
        if(code != AnimCodes.DODGE)
        {
            Debug.Log("animDodge_action code錯誤,code:" + code);
        }
        else
        {
            control.GetComponent<roleAnim>().anim_dodge(conditionNext);
        }

    }
}
public class animDeath_action : stage_action
{
    public animDeath_action(List<object> argList):base(move.Anim,argList)
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
        if (code != AnimCodes.DEATH)
        {
            Debug.Log("animDodge_action code錯誤,code:" + code);
        }
        else
        {
            control.GetComponent<roleAnim>().anim_died();
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
public class hpBarUpdate_action : stage_action
{
    public hpBarUpdate_action( List<object> argList) : base(move.hpChange, argList)
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
        ((roleAnim)argList[0]).setHpBar(((float)argList[1]));
    }
}
public class floatNum_action : stage_action
{
    public Vector2 numOffset = new Vector2(0, 2f);
    public floatNum_action(List<object> argList) : base(move.floatNum, argList)
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
        int num = (int)argList[1];
        int kind = (int)argList[2];
        NumberCreater.main.CreateFloatingNumber(num, control.transform.position+(Vector3)numOffset, kind);
    }
}
public class floatText_action : stage_action
{
    public Vector2 numOffset = new Vector2(0, 1f);
    protected int stageNo=3;
    public floatText_action(List<object> argList,int stageNum) : base(move.floatNum, argList)
    {
        stageNo = stageNum;
    }
    public override int stage
    {
        get
        {
            return stageNo;
        }
    }
    public override void action(skillpackage skp)
    {
        comboControler control = (comboControler)argList[0];
        int kind = (int)argList[1];
        ((TextCreater)(NumberCreater.main)).createText(kind, control.transform.position+(Vector3)numOffset);
    }
}

public class createEffect_hit : stage_action
{
    public createEffect_hit(List<object> argList) : base(move.Effection, argList)
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
        GameObject prafeb = (GameObject)argList[0];
        Dictionary<string, object> initDict = (Dictionary<string, object>)argList[1];
        closeupStage.main.createEffect(prafeb,initDict);
    }
}
public class createEffect_record : stage_action
{
    int selfStage = 3;
    public createEffect_record(List<object> argList) : base(move.Effection, argList)
    {
    }
    public override int stage
    {
        get
        {
            return selfStage;
        }
    }

    public override void action(skillpackage skp)
    {
        GameObject prafeb = (GameObject)argList[0];
        Dictionary<string, object> initDict = (Dictionary<string, object>)argList[1];
        string key = (string)argList[2];
        closeupStage.main.createEffect(prafeb, initDict,key);
    }
}
public class createEffect : stage_action_withskp
{
    public createEffect(List<object> argList) : base(move.Effection, argList)
    {
    }
    public override int stage
    {
        get
        {
            return 2;
        }
    }
    protected virtual void missileHit(missile missile)
    {
        conditionNext();
    }
    public override void action(skillpackage skp)
    {
        GameObject prafeb = (GameObject)argList[0];
        Dictionary<string, object> initDict = (Dictionary<string, object>)argList[1];
        missile.withMissile callback = missileHit;
        initDict["callback"] = callback;
        closeupStage.main.createEffect(prafeb, initDict);
    }
}
public class showSIcon : stage_action
{
    public showSIcon(List<object> argList) : base(move.Effection, argList)
    {
    }
    public override int stage
    {
        get
        {
            return 1;
        }
    }

    public override void action(skillpackage skp)
    {
        roleAnim ranim = (roleAnim)argList[0];
        Sprite Icon = (Sprite)argList[1];
        ranim.showSkillIcon(Icon);
    }
}
public class switchOff : stage_action
{
    public switchOff(List<object> list) : base(move.OffEffectByKey,list)
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
        string key = (string)argList[0];
        closeupStage.main.effectRecords[key].GetComponent<switchEff>().off();
    }

}
