using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class process
{
    public abstract bool Waste
    {
        get;
    }
    protected float timeLeft;
    public process(float time)
    {
        timeLeft = time;
    }
    public abstract void update(float time);
}
class shake:process
{
    private float dist;
    private Transform transform;
    private Vector2 oriPos;
    private bool waste=false;

    public override bool Waste
    {
        get
        {
            return waste;
        }
    }

    //private System.Random random;
    public shake(float time,float maxdist,Transform transform,Vector2 oriPos):base(time)
    {
        timeLeft = time;
        dist = maxdist;
        this.oriPos = oriPos;
        this.transform = transform;
        //random = new System.Random();
    }

    public override void update(float time)
    {
        
        timeLeft -= time;
        Debug.Log("shake updateing... time:"+timeLeft);
        Vector2 offset = UnityEngine.Random.insideUnitCircle*dist;
        transform.position = oriPos + offset;
        if (timeLeft <= 0)
        {
            transform.position = oriPos;
            waste = true;
        }
    }
}

public class sp_effection : MonoBehaviour {
    protected Vector2 oriPos;
    protected float timeleft;
    List<process> processList;
	// Use this for initialization
	void Start () {
        oriPos = transform.position;
        processList = new List<process>();
	}
    
	// Update is called once per frame
	void Update () {
        Debug.Log("sp_effection update processList len:"+processList.Count);
        float delta = Time.deltaTime;
		foreach(process p in processList)
        {
            p.update(delta);
        }
        for(int i = 0; i < processList.Count; i++)
        {
            if (processList[i].Waste)
            {
                processList.RemoveAt(i--);
            }
        }
	}
    public void shakeStart(float during,float dist)
    {
        processList.Add(new shake(during, dist,transform,oriPos));
    }
}
