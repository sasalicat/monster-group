using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillTest : CDSkill {
    public override bool canUse
    {
        get
        {
            return true;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return 1;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        return null;
    }

    public override void onInit(unitControler owner)
    {
        
    }

    public override void trigger(Dictionary<string, object> args)
    {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
