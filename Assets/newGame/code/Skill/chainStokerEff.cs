using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainStokerEff : chain_stoker, effectionInit
{
    //missile.withMissile beforeDestroy;
    BasicDelegate.withNone beforeDestroy;
    public void init(Dictionary<string, object> effDict, GameObject prafeb)
    {
        unitControler[] tragets= (unitControler[])effDict["tragets"];
        base.tragets = new List<GameObject>() {((BasicControler)effDict["creater"]).gameObject};
        foreach(comboControler control in tragets)
        {
            base.tragets.Add(closeupStage.main.controler2roleAnim[control].centerPointObj);
        }
        //missile.withMissile cb = (missile.withMissile)effDict["callback"];
        BasicDelegate.withNone cb = (BasicDelegate.withNone)effDict["callback"];
        beforeDestroy += cb;
    }
    public void OnDestroy() {
        //beforeDestroy(null);
        beforeDestroy();
    }
}
