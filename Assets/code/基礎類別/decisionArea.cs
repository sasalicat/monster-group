using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decisionArea : MonoBehaviour {
    protected float timeLeft;
    public float time;
	// Use this for initialization
	void Start () {
        timeLeft = time;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
	}
}
