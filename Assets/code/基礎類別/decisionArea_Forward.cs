using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decisionArea_Forward : decisionArea {
    public Vector3 direction = new Vector3(1, 1, 1);
    public float speed = 1;
	// Use this for initialization
    protected new void Update()
    {
        transform.Translate(direction.normalized*Time.deltaTime*speed);
        base.Update();
    }
}
