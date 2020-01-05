using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class commonHitEff : decisionArea,effectionInit {
    public Vector2 positiveDirection;
    public virtual void init(Dictionary<string, object> effDict,GameObject selfPrafeb)
    {
        comboControler traget = (comboControler)effDict["traget"];
        comboControler creater = (comboControler)effDict["creater"];
        roleAnim ranim = closeupStage.main.controler2roleAnim[traget];
        transform.position = (Vector2)ranim.Center+(Vector2)selfPrafeb.transform.position;
        Vector2 toTraget = traget.transform.position - creater.transform.position;
        Quaternion rotater = Quaternion.FromToRotation(positiveDirection, toTraget);
        transform.up = rotater * transform.up;
    }
}
