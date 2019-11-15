using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeupStage : MonoBehaviour,battleStage {
    protected delegate void clock(float time);

    public GameObject cameraObj;
    public Vector3 camera_closeUp = new Vector3(-2.76f, -2.33f, -4.46f);
    public Vector3 camera_normal = new Vector3(0.6f, -1.21f,-8.27f);
    public float closeUp_time = 0.3f;
    protected float timeBefore = 0;
    protected clock clockFunc;
    public GameObject[] team1;
    public GameObject[] team2;
    protected void closeUp_process(float time)
    {
        Debug.Log("closeUp_process timeBefore:"+timeBefore);
        timeBefore += time;
        if (timeBefore >= closeUp_time)//計時完成
        {
            clockFunc = null;
            timeBefore = closeUp_time;
        }
        Vector3 cam_offset = camera_closeUp - camera_normal;
        cameraObj.transform.position = camera_normal + (timeBefore / closeUp_time) * cam_offset;
        //timeBefore = 0;
    }
    protected void unCloseUp_process(float time)
    {
        Debug.Log("uncloseUp_process timeBefore:" + timeBefore);
        timeBefore += time;
        if (timeBefore >= closeUp_time)//計時完成
        {
            clockFunc = null;
            timeBefore = closeUp_time;
        }
        Vector3 cam_offset = camera_normal- camera_closeUp;
        cameraObj.transform.position = camera_closeUp + (timeBefore / closeUp_time) * cam_offset;

    }
    public void display_damage(unitControler who, Damage damage)
    {
        throw new NotImplementedException();
    }

    public void display_effect(GameObject effectPrefab, unitControler creater, Dictionary<string, object> initArgs)
    {
        throw new NotImplementedException();
    }

    public void display_number(unitControler who, int number, int kind)
    {
        throw new NotImplementedException();
    }
    public void closeUp()
    {
        if (clockFunc == null)
        {
            timeBefore = 0;
            clockFunc = closeUp_process;
            
        }
    }
    public void uncloseUp() {
        if (clockFunc == null)
        {
            timeBefore = 0;
            clockFunc = unCloseUp_process;
        }
    }
    // Use this for initialization
    void Start () {
        cameraObj = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (clockFunc != null) {
            clockFunc(Time.deltaTime);
        }
	}
}
