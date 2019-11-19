using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeupStage : MonoBehaviour,battleStage {
    const int BEHIT = 0;
    const int ATTACK = 1;
    const int MAGIC = 2;

    protected delegate void clock(float time);
    public delegate void with_movement(stage_movement move);

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

    protected skill_movement rootMovement;
    protected List<skill_movement> heap;
    protected with_movement[] handleFuncs;
    public static closeupStage main=null; 
    //記錄當前黑幕前有哪些角色
    unitControler now_protagonist;
    unitControler now_tragets;
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
    //提交order的function
    public void display_effect(GameObject effectPrefab, unitControler creater, Dictionary<string, object> initArgs)
    {
        stage_movement newone = new stage_movement(stage_movement.move.Number, new List<object>() { effectPrefab, creater, initArgs });
        heap[0].argList.Add(newone);
    }

    public void display_number(unitControler who, int number, int kind)
    {
        stage_movement newone = new stage_movement(stage_movement.move.Number, new List<object>() { who, number, kind });
        heap[0].argList.Add(newone);
    }
    public void display_skill(unitControler protagonist, Skill skill, List<unitControler> tragets, bool isTrigger)
    {
        skill_movement before = heap[0];
        heap.Insert(0, new skill_movement(stage_movement.move.SkillStart, new List<object>(), protagonist, tragets, before.user,new List<unitControler>(before.tragets.ToArray())));
        heap[0].isTrigger = isTrigger;
    }
    public void display_skillEnd()
    {
        stage_movement nowMove = heap[0];
        heap.RemoveAt(0);
        heap[0].argList.Add(nowMove);

    }
    public void display_anim(unitControler unit, int code)
    {
        heap[0].argList.Add(new stage_movement(stage_movement.move.Anim, new List<object>() {unit,code}));
    }
    //-------------------------------------------
    public void closeUp(comboControler protagonist)
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
    void OnEnable()
    {
        if (main != null)
        {
            Destroy(this);
        }
        else {
            main = this;
        }
    }
    // Use this for initialization
    void Start () {
        cameraObj = Camera.main.gameObject;
        rootMovement = new skill_movement(stage_movement.move.SkillStart, new List<object>(),null,null,null,null);
        handleFuncs = new with_movement[6];
        handleFuncs[(int)stage_movement.move.SkillStart] = handle_SkillStart;
	}
	
	// Update is called once per frame
	void Update () {
        if (clockFunc != null) {
            clockFunc(Time.deltaTime);
        }
        if (((skill_movement)rootMovement.argList[0]).nowState == stage_movement.state.unActive)
        {
            handleFuncs[(int)stage_movement.move.SkillStart]((skill_movement)rootMovement.argList[0]);
        }
        else if (((skill_movement)rootMovement.argList[0]).nowState == stage_movement.state.Finish)
        {
            rootMovement.argList.RemoveAt(0);
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
    protected void aft_closeUp(stage_movement movement)
    {
        for (int i = 0; i < movement.argList.Count; i++)
        {
            stage_movement nowMove = (stage_movement)movement.argList[i];
            handleFuncs[(int)nowMove.order](nowMove);
        }  
    }
    //處理order的function
    protected void handle_SkillStart(stage_movement movement)
    {
        bool isTrigger = ((skill_movement)movement).isTrigger;
        if (!isTrigger)//如果不是觸發產生的技能
        {
            //復原close up
            uncloseUp();
        }
        else
        {

        }
     
    }
    protected void handle_SkillEnd(stage_movement movement)
    {

    }
}
abstract class state_machine
{
    state_machine(stage_movement movement){

    }
    abstract void Next(object arg);
}
class handle_SkillStart : state_machine
{
    skill_movement now_movement;
    void Next(object arg)
    {

    }
    handle_SkillStart(stage_movement movement)
    {
        now_movement = (skill_movement)movement;
        bool isTrigger = ((skill_movement)movement).isTrigger;
        if (!isTrigger)//如果不是觸發產生的技能
        {
            //復原close up
            uncloseUp();
        }
        else
        {

        }
    }
}