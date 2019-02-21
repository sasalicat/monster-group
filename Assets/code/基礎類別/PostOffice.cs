using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PostOffice:MonoBehaviour  {
    public delegate void Empty();
    public static PostOffice main;
    public  float cycleTime=0.03f;
    private float frameTimeLeft=0;
    public abstract void addOrder(Dictionary<string, object> order);
    public Empty beforeFrameEnd;
    private int counter = 0;
    protected void OnEnable()
    {
        frameTimeLeft = cycleTime;
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
    }

    protected void Update()
    {
        frameTimeLeft -= Time.deltaTime;
        //Debug.Log("deltaTime:" + Time.deltaTime);
        //Debug.Log("in post office update:"+frameTimeLeft);
        if (frameTimeLeft <= 0)
        {
            //Debug.Log("send");
            if(beforeFrameEnd!=null)
                beforeFrameEnd();
            updateFrame();
            frameTimeLeft = cycleTime;
            counter++;
        }
       
    }
     public abstract void updateFrame();
}
