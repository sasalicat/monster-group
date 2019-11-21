using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decisionArea : MonoBehaviour {
    protected float timeLeft;
    public float time;
    protected bool Timer=true;
    // Use this for initialization
	protected void Start () {
        //Debug.Log(gameObject.name + "初始化 time:" + time);
        if(time <0){
            Timer = false;
        }
        timeLeft = time;
	}
	
	// Update is called once per frame
	protected void Update () {
        if (Timer)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                Destroy(gameObject);
            }
        }
	}
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
