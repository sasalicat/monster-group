using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleEff : decisionArea, effectionInit
{ 
    public void init(Dictionary<string, object> effDict, GameObject prafeb)
    {
        transform.position = (Vector2)effDict["position"];
    }
}
