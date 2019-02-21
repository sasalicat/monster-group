using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDriver : PostOffice {

    public override void addOrder(Dictionary<string, object> order)
    {
        
    }

    public override void updateFrame()
    {
        Timer.main.callAllFunction(cycleTime);
    }

    // Use this for initialization
    void Start () {
        cycleTime = 0.05f;

    }
	
}
