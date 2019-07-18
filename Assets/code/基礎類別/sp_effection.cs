using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class process
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
public class rush_stay : process
{
    protected bool waste = false;
    protected float anim_time = 0;
    protected float stay_time = 0;
    protected float animTime = 0;
    protected float stayTime = 0;
    protected Transform transform = null;
    protected GameObject nowTraget = null;
    protected Vector2 oriPos;
    protected bool triggerEff =false;
    public readonly Vector2 offset = new Vector2(0.7f, 0.7f);
    protected BasicDelegate.withNone onTriggerEff;
    public rush_stay(float anim_time,float stay_time,Transform transform,GameObject traget,Vector2 oriPos,BasicDelegate.withNone callback) : base(anim_time)
    {
        this.transform = transform;
        this.animTime = anim_time;
        this.stayTime = stay_time;
        nowTraget = traget;
        this.oriPos = oriPos;
        onTriggerEff = callback;
    }

    public override bool Waste
    {
        get
        {
            return waste;
        }
    }

    public override void update(float time)
    {
        //Debug.Log("rush main update________________________________________");
        anim_time += time;
        if (anim_time <= animTime)
        {
            //Debug.Log("anim_time=" + anim_time + " animTime=" + animTime);
            float process = anim_time / animTime;
            process = EasingFunction.EaseInCubic(0, 1, process);
            Vector2 nowOffset = offset;
            if(nowTraget == null)
            {
                transform.position = oriPos;
                waste = true;
                return;
            }
            Vector2 dist = nowTraget.transform.position - transform.position;
            if (Mathf.Abs(dist.x) < nowOffset.x)
            {
                nowOffset.x = Mathf.Abs(dist.x);
            }
            if (Mathf.Abs(dist.y) < nowOffset.y)
            {
                nowOffset.y = Mathf.Abs(dist.y);
            }
            //Debug.Log("count"+count+" tragetPos:" + (Vector2)nowTraget.transform.position + " oriPos:" + oriPos+" ans:" + ((Vector2)nowTraget.transform.position - oriPos) * process);


                Vector2 toTraget = ((Vector2)nowTraget.transform.position - oriPos);
                if (toTraget.x > 0)
                {
                    toTraget.x -= nowOffset.x;
                }
                else
                {
                    toTraget.x += nowOffset.x;
                }
                if (toTraget.y > 0)
                {
                    toTraget.y -= nowOffset.y;
                }
                else
                {
                    toTraget.y += nowOffset.y;
                }
                transform.position = oriPos + toTraget * process;
                /*if (stay_time >=  stayTime && !triggerEff)
                {
                    GameObject neweff= Instantiate(objectList.main.prafebList[0], transform);
                    neweff.transform.localPosition = Vector2.zero;
                    toTraget = (Vector2)transform.position - (Vector2)nowTraget.transform.position;
                    neweff.transform.right = toTraget;
                    triggerEff = true;
                }*/
            
        }
        else if (stay_time < stayTime)
        {
            if (!triggerEff)
            {
                Debug.Log("觸發效果");
                onTriggerEff();
                triggerEff = true;
            }
            //Debug.Log("count" + count + "staying");
            stay_time += time;
        }
        else
        {
            transform.position = oriPos;
            waste = true;
        }
    }
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
        //Debug.Log("shake updateing... time:"+timeLeft);
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
    public rush_stay rush_main;
	// Use this for initialization
	void Start () {
        oriPos = transform.position;
        processList = new List<process>();
	}
    
	// Update is called once per frame
	void Update () {
        //Debug.Log("sp_effection update processList len:"+processList.Count);
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
    public void rushUpdate(float time)
    {
        rush_main.update(time);
        if (rush_main.Waste)
        {
            rush_main = null;
            Timer.main.loginOutTimer(rushUpdate);
        }
       // Debug.Log("移除rushUpdate");


    }
    public void shakeStart(float during,float dist)
    {
        processList.Add(new shake(during, dist,transform,oriPos));
    }
    public bool rushMainStart(float animTime,float stayTime,GameObject traget,BasicDelegate.withNone callback)
    {
        if (rush_main != null)
        {
            return false;
        }
        else
        {
            rush_main = new rush_stay(animTime, stayTime, transform, traget, oriPos,callback);
            Timer.main.logInTimer(rushUpdate);
            return true;
        }
    }
}
