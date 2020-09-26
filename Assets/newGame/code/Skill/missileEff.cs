using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileEff :missile,effectionInit
{
    protected Dictionary<string, object> args;
    protected roleAnim traget_ranim;
    BasicDelegate.withNone callback;
    public override Vector2 tragetPoint
    {
        get
        {
            return traget_ranim.Center;
        }
    }
    //protected BasicDelegate.withBasicDict onEnd=null;
    protected void misHitted(missile selfObj)
    {
        if(callback!=null)
            callback();
    }
    public void init(Dictionary<string, object> effDict, GameObject prafeb)
    {
        traget = ((comboControler)effDict["traget"]).gameObject;
        traget_ranim = closeupStage.main.controler2roleAnim[(comboControler)effDict["traget"]];
        comboControler creater = ((comboControler)effDict["creater"]);
        BasicDelegate.withNone cb = (BasicDelegate.withNone)effDict["callback"];
        transform.position = (Vector2)closeupStage.main.controler2roleAnim[creater].Center + (Vector2)prafeb.transform.position;
        args = effDict;
        callback += cb;
        on_missile_hited += misHitted;
        Timer = false;
    }
    public void OnDestroy()
    {
        Debug.Log("missile 被銷毀");
    }
}
