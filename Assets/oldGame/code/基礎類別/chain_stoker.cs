﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chain_stoker : chain {
    public List<GameObject> tragets;
	// Use this for initialization
	
	// Update is called once per frame
	protected new void Update () {
        base.points.Clear();
        foreach(GameObject traget in tragets)
        {
            if(traget !=null)
                points.Add(traget.transform.position);
        }
        /*
        for(int i = 0; i < 10; i++)
        {
            points.Add(new Vector3(i, i, 0));
        }*/
        base.Update();
	}
}
