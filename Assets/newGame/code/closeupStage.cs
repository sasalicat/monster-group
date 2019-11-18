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
    public BasicControler[] team1;
    public BasicControler[] team2;
    public GameObject curtain;
    public const int CURTAIN_MASKER_NUMBER = 101;
    protected stage_movement rootMovement;
    protected List<stage_movement> heap;
    //記錄當前黑幕前有哪些角色

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

    public void display_effect(GameObject effectPrefab, unitControler creater, Dictionary<string, object> initArgs)
    {
        stage_movement newone = new stage_movement(move.Number, new List<object>() { effectPrefab, creater, initArgs });
    }

    public void display_number(unitControler who, int number, int kind)
    {
        stage_movement newone = new stage_movement(move.Number, new List<object>() {who,number,kind});

    }
    public void display_skill(unitControler protagonist, Skill skill, List<unitControler> tragets) {
        heap.insert(new stage_movement(move.SkillStart,new List<object>()));
        heap[0].argList.Add(protagonist);
        heap[0].argList.Add(tragets);
    }
    public void display_skillEnd()
    {
        stage_movement nowMove = heap[0];
        heap.RemoveAt(0);
        heap[0].argList.Add(nowMove);

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
    public void setCurtain(bool torf)
    {
        curtain.SetActive(torf);
    }
    // Use this for initialization
    void Start () {
        cameraObj = Camera.main.gameObject;
        rootMovement = rootMovement(move.SkillStart,new List<object>());
	}
	
	// Update is called once per frame
	void Update () {
        if (clockFunc != null) {
            clockFunc(Time.deltaTime);
        }
	}
    public void display_onStage(unitControler actioner,unitControler[] tragets){
        setCurtain(true);
        ((BasicControler)actioner).GetComponent<roleAnim>().addSortLayout(CURTAIN_MASKER_NUMBER);
        foreach (unitControler unit in tragets)
        {
            ((BasicControler)unit).GetComponent<roleAnim>().addSortLayout(CURTAIN_MASKER_NUMBER);
        }
    }
}
