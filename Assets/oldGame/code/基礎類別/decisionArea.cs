using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decisionArea : MonoBehaviour {
    protected float timeLeft;
    public float time;
    // Use this for initialization
	protected void Start () {
        //Debug.Log(gameObject.name + "初始化 time:" + time);
        timeLeft = time;
	}
	
	// Update is called once per frame
	protected void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
	}
}
