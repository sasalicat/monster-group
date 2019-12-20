using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileEff :missile,effectionInit
{
    protected Dictionary<string, object> args;
    //protected BasicDelegate.withBasicDict onEnd=null;
    /*protected void misHitted(missile selfObj)
    {
        onEnd(args);
    }*/
    public void init(Dictionary<string, object> effDict, GameObject prafeb)
    {
        comboControler traget = (comboControler)effDict["traget"];
        withMissile cb = (withMissile)effDict["callback"];
        transform.position = traget.transform.position + prafeb.transform.position;
        args = effDict;
        on_missile_hited += cb;
    }
}
