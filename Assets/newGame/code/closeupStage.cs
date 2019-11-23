using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeupStage : MonoBehaviour, battleStage
{

    public const int CU_RIGHT_TOLEFT = 0;
    public const int CU_LEFT_TORIGHT = 1;
    public const int CU_RIGHT_ONLY = 2;
    public const int CU_LEFT_ONLY = 3;
    public const int CU_NOCU = 4;
    protected enum cu_state {no_cu,cu_ing,cu_ed};//標記當前鏡頭的closeUp狀態
    protected delegate void clock(float time);
 //   public delegate object with_movement(stage_movement move);
    public delegate void with_skillpackage(stage_movement move,skillpackage skp);
    public delegate void with_nothing();
    public GameObject cameraObj;
    public Vector3 camera_closeUp_right2left = new Vector3(-2.76f, -2.33f, -4.46f);
    public Vector3 camera_closeUp_left2right = new Vector3(2.76f, -2.33f, -4.46f);
    public Vector3 camera_normal = new Vector3(0.6f, -1.21f, -8.27f);
    public Vector3 camera_now_traget = new Vector3(0,0,0);
    public Vector3 camera_uncloseup_begin;
    public int closeUpState = 0;
    public float closeUp_time = 0.3f;
    public float reCloseUpWait_time = 0.5f;
    protected float timeBefore = 0;
    protected clock clockFunc;
    public Vector3[] team1_pos;
    public Vector3[] team1_closePoint;
    public BasicControler[] team1;
    public Vector3[] team2_pos;
    public Vector3[] team2_closePoint;
    public BasicControler[] team2;
    public GameObject curtain;
    public GameObject rolePrefab;
    public const int CURTAIN_MASKER_NUMBER = 101;
    protected cu_state Cstate=cu_state.no_cu;
    //用於存放異步的order
    protected skill_movement rootMovement;
    protected List<skill_movement> heap;
    protected with_skillpackage[] handleFuncs;
    public static closeupStage main = null;
    //記錄當前黑幕前有哪些角色
    unitControler now_protagonist;
    unitControler now_tragets;
    //用於解讀異步的order
    public List<skillpackage> packages=new List<skillpackage>();
    public with_nothing next_closeUpEnd;
    protected void closeUp_process(float time)
    {
        Debug.Log("closeUp_process timeBefore:" + timeBefore);
        timeBefore += time;
        if (timeBefore >= closeUp_time)//計時完成
        {
            clockFunc = null;
            timeBefore = closeUp_time;
            Cstate = cu_state.cu_ed;
            if (next_closeUpEnd != null)
            {
                next_closeUpEnd();
                next_closeUpEnd = null;
            }
        }
        Vector3 cam_offset = camera_now_traget - camera_normal;
        cameraObj.transform.position = camera_normal + (timeBefore / closeUp_time) * cam_offset;
        //timeBefore = 0;
    }
    public with_nothing next_unCloseUpEnd;
    protected void unCloseUp_process(float time)
    {
        Debug.Log("uncloseUp_process timeBefore:" + timeBefore);
        timeBefore += time;
        if (timeBefore >= closeUp_time)//計時完成
        {
            clockFunc = null;
            timeBefore = closeUp_time;
            Cstate = cu_state.no_cu;
            if(next_unCloseUpEnd != null)
            {
                next_unCloseUpEnd();
                next_unCloseUpEnd = null;
            }
        }
        Vector3 cam_offset = camera_normal - camera_uncloseup_begin;
        cameraObj.transform.position = camera_uncloseup_begin + (timeBefore / closeUp_time) * cam_offset;

    }
    protected void reCloseUp_process(float time)
    {
        timeBefore += time;
        if (timeBefore < closeUp_time)//歸位鏡頭
        {
            Cstate = cu_state.cu_ing;
            Vector3 cam_offset = camera_normal - camera_uncloseup_begin;
            cameraObj.transform.position = camera_uncloseup_begin + (timeBefore / closeUp_time) * cam_offset;
        }
        else if (timeBefore < closeUp_time + reCloseUpWait_time)//等待階段
        {
            Cstate = cu_state.no_cu;
        }
        else if (timeBefore < closeUp_time * 2 + reCloseUpWait_time)//再次特寫
        {
            Cstate = cu_state.cu_ing;
            Vector3 cam_offset = camera_now_traget - camera_normal;
            cameraObj.transform.position = camera_normal + (timeBefore / closeUp_time) * cam_offset;
        }
        else {//完成
            clockFunc = null;
            //timeBefore = closeUp_time;
            Cstate = cu_state.cu_ed;
            if (next_closeUpEnd != null)
            {
                next_closeUpEnd();
                next_closeUpEnd = null;
            }
            cameraObj.transform.position = camera_now_traget;
        }
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
        heap.Insert(0, new skill_movement(stage_movement.move.SkillStart, new List<object>(), protagonist, tragets, before.user, new List<unitControler>(before.tragets.ToArray())));
        heap[0].isTrigger = isTrigger;
        if (!heap[0].isTrigger)
        {

        }
    }
    public void display_skillEnd()
    {
        stage_movement nowMove = heap[0];
        heap.RemoveAt(0);
        heap[0].argList.Add(nowMove);

    }
    public void display_anim(unitControler unit, int code)
    {
        if (code== roleAnim.BEHIT)
        {
            heap[0].argList.Add(new animBenhit_action(stage_movement.move.Anim,new List<object>() {unit,code}));
        }
        else
        {
            heap[0].argList.Add(new animSkill_action(stage_movement.move.Anim, new List<object>() { unit, code }));
        }
        //heap[0].argList.Add(new stage_movement(stage_movement.move.Anim, new List<object>() { unit, code }));
    }
    //-------------------------------------------
    public void closeUp(int kind)
    {
        switch(kind){
            case CU_RIGHT_TOLEFT: {
                camera_now_traget = camera_closeUp_right2left;
                break;
            }
            case CU_LEFT_TORIGHT:
            {
                camera_now_traget = camera_closeUp_left2right;
                break;
            }
        }
        if (clockFunc == null)
        {
            timeBefore = 0;
            clockFunc = closeUp_process;
            Cstate = cu_state.cu_ing;
        }
    }
    public void closeUp(int kind,with_nothing end_cb)
    {
        closeUp(kind);
        next_closeUpEnd += end_cb;
    }
    public void uncloseUp()
    {
        if (clockFunc == null)
        {
            timeBefore = 0;
            clockFunc = unCloseUp_process;
            camera_uncloseup_begin = cameraObj.transform.position;
            Cstate = cu_state.cu_ing;
        }
    }
    public void uncloseUp(with_nothing end_cb)
    {
        uncloseUp();
        next_unCloseUpEnd += end_cb;
    }
    public void recloseUp(int kind)
    {
        switch (kind)
        {
            case CU_RIGHT_TOLEFT:
                {
                    camera_now_traget = camera_closeUp_right2left;
                    break;
                }
            case CU_LEFT_TORIGHT:
                {
                    camera_now_traget = camera_closeUp_left2right;
                    break;
                }
        }
        if (clockFunc == null)
        {
            if (Cstate == cu_state.cu_ed)
            {
                camera_uncloseup_begin = cameraObj.transform.position;
                timeBefore = 0;
            }
            else
            {
                timeBefore = closeUp_time+ reCloseUpWait_time;
            }
            
            clockFunc = reCloseUp_process;
            Cstate = cu_state.cu_ing;
        }
    }
    public Vector3 getClosePos(List<unitControler> roles) {
        List<int[]> posList = new List<int[]>();
        ChessBoard cbd = ((comboManager)BasicManager.main).ChessBoard;
        foreach (unitControler role in roles) {
            int[] pos = cbd.getPosFor(role);
            posList.Add(pos);
        }
        bool enemy = false;
        if (posList[0][1]< (cbd.Y / 2))
        {
            enemy = true;
        }
        int forwardY = cbd.Y / 2 - 1;
        bool row1 = false;
        bool row2 = false;
        foreach (int[] pos in posList)
        {

            if (enemy)
            {
                if (pos[1] >= (cbd.Y / 2))
                {
                    Debug.LogError("錯誤的close pos請求,有不同陣營的角色");
                    return Vector3.zero;
                }
                int realY = cbd.Y / 2 - pos[1]-1;
                if (realY < forwardY)
                {
                    forwardY = realY;
                }
                if (pos[0] == 0)
                {
                    row2 = true;
                }
                else {
                    row1 = true;
                }
            }
            else {
                if (pos[1] < (cbd.Y / 2)) {
                    Debug.LogError("錯誤的close pos請求,有不同陣營的角色");
                    return Vector3.zero;
                }
                int realY = pos[1] - cbd.Y / 2;
                if (realY < forwardY)
                {
                    forwardY = realY;
                }
                if (pos[0] == 0)
                {
                    row2 = true;
                }
                else
                {
                    row1 = true;
                }
            }

        }
        if (enemy)
        {
            int teamLen = team2.Length / 2;
            if (row1 && row2)
            {
                return (team2_closePoint[forwardY] + team2_closePoint[forwardY + teamLen]) / 2;
            }
            else if (row1)
            {
                return team2_closePoint[forwardY + teamLen];
            }
            else if (row2)
            {
                return team2_closePoint[forwardY];
            }
            else
            {
                Debug.LogError("錯誤的位置既不是row1也不是row2");

            }
        }
        else {
            int teamLen = team1.Length / 2;
            if (row1 && row2)
            {
                return (team1_closePoint[forwardY] + team1_closePoint[forwardY + teamLen]) / 2;
            }
            else if (row1)
            {
                return team1_closePoint[forwardY + teamLen];
            }
            else if (row2)
            {
                return team1_closePoint[forwardY];
            }
            else
            {
                Debug.LogError("錯誤的位置既不是row1也不是row2");

            }
        }
        return new Vector3(0,0,0);
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
        else
        {
            main = this;
        }
    }
    // Use this for initialization
    void Start()
    {
        cameraObj = Camera.main.gameObject;
        rootMovement = new skill_movement(stage_movement.move.SkillStart, new List<object>(), null, new List<unitControler>(), null, null);
        handleFuncs = new with_skillpackage[6];
        heap = new List<skill_movement>();
        heap.Add(rootMovement);
        //handleFuncs[(int)stage_movement.move.SkillStart] = SkillStart_for;
    }

    // Update is called once per frame
    void Update()
    {
        if (clockFunc != null)
        {
            clockFunc(Time.deltaTime);
        }

            //if (((skill_movement)rootMovement.argList[0]).nowState == stage_movement.state.unActive)
            if (packages.Count ==0)//如果沒有skillpackage
            {
                if (rootMovement.argList.Count > 0)//還有skill_movement需要處理
                {
                //handleFuncs[(int)stage_movement.move.SkillStart]((skill_movement)rootMovement.argList[0]);
                    //則解析目前的第一個skill_movement
                    packages = SkillStart_for((skill_movement)rootMovement.argList[0]);
                    rootMovement.argList.RemoveAt(0);
                    packages[0].Next();

                }   
            }
            else if (packages[0].End)//如果當前的skillpackage已經結束
            {
                packages.RemoveAt(0);//則移除當前的skillpackage并執行下一個
                if(packages.Count>0)
                    packages[0].Next();
            }
        
    }
    public void display_onStage(unitControler actioner, unitControler[] tragets)
    {
        setCurtain(true);
        ((BasicControler)actioner).GetComponent<roleAnim>().addSortLayout(CURTAIN_MASKER_NUMBER);
        foreach (unitControler unit in tragets)
        {  
            ((BasicControler)unit).GetComponent<roleAnim>().addSortLayout(CURTAIN_MASKER_NUMBER);
        }
    }
    /*
    protected void aft_closeUp(stage_movement movement)
    {
        for (int i = 0; i < movement.argList.Count; i++)
        {
            stage_movement nowMove = (stage_movement)movement.argList[i];
            handleFuncs[(int)nowMove.order](nowMove);
        }
    }*/

    //處理order的function

    protected void skm2skp(skill_movement skm,List<skillpackage> skpList)//遞迴function用來把skill_movement轉化為skillpackage,skill_movement是巢狀結構,這個方法包含把巢狀結構轉化為線性結構:
                                                                         // 例如skm0{skm1{skm3},skm2} => skp0,skm1,skm3,skm2
    {
        skillpackage nowpackage = new skillpackage(skm);
        skpList.Add(nowpackage);
        foreach (stage_movement move in skm.argList)
        {
            if (move.order != stage_movement.move.SkillStart)
            {
                ((stage_action)move).onLoad(nowpackage);
            }
            else
            {
                skm2skp((skill_movement)move, skpList);
            }
        }
    }
    protected List<skillpackage> SkillStart_for(stage_movement move){
        //nowMachine = new handle_SkillStart(move);
        packages = new List<skillpackage>();
        skm2skp((skill_movement)move,packages);
        return packages;
    }/*
    protected void Anim_for(stage_movement move,skillpackage skp)
    {

    }*/
}
public delegate void skillpackage_func(skillpackage package);
public abstract class state_machine
{

    public state_machine(stage_movement movement)
    {

    }
    public abstract void Next(object arg);
    public abstract void Next();
}

public class skillpackage : state_machine
{
    int stage_no=-1;
    int stage
    {
        get
        {
            return stage_no;
        }
        set
        {
            stage_no = value;
            Debug.Log("stage to " + value);
        }
    }
              //stage0開始前置作業,目前為拉近鏡頭,移動角色到攻擊位置
              //stage1開始角色的攻擊動畫 stage1->2為對應攻擊動畫觸發doEffect
              //stage2專為missile設計,如果沒有創建missile則跳過這個stage stage2->3為所有missile hit觸發
              //stage3依次開始所有目標的behit動畫和創建被擊特效 stage3->4為所有behit動畫結束
              //stage4設置為End 為True,整個技能的表現結束
    skill_movement now_movement;
    public List<object> stage2_condition;//存還未打中的missile
    public List<object> stage3_condition;//存還未完成的動畫
    public skillpackage_func[] stage_funcs;

    public override void Next(object arg)//這個Next是用於stage2 missile擊通知,和stage3所有角色的被擊動畫完成通知
    {
        if (stage != 2 && stage != 3) {//如果不是在stage2/stage3呼叫就是不正常現象
            return;
        }
        bool condition_meet = false;
        if (stage == 2)
        {
            stage2_condition.Remove(arg);
            if (stage2_condition.Count == 0)
            {
                condition_meet = true;
            }
        }
        if (stage == 3)
        {
            stage3_condition.Remove(arg);
            if (stage3_condition.Count == 0)
            {
                condition_meet = true;
            }
        }
        if (condition_meet)
        {
            stage++;
            while (stage < 4 && stage_funcs[stage] == null)
            {
                stage++;
            }
            if (stage_funcs[stage] != null)
                stage_funcs[stage](this);
        }
    }
    public override void Next()//反之
    {
        if (stage == 2 || stage == 3) {
            return;
        }
        stage++;
        while (stage < 4 && stage_funcs[stage] == null)
        {
            stage++;
        }
        if(stage_funcs[stage] != null)
            stage_funcs[stage](this);
       
    }
    public skillpackage(stage_movement movement)
        : base(movement)
    {
        now_movement = (skill_movement)movement;
        bool isTrigger = ((skill_movement)movement).isTrigger;
        stage_funcs = new skillpackage_func[5];
        stage2_condition = new List<object>();
        stage3_condition = new List<object>();
        /*if (!isTrigger)//如果不是觸發產生的技能
        {
            //復原close up
            closeupStage.main.uncloseUp();
        }
        else
        {

        }*/
    }
    public bool End
    {
        get
        {
            return stage >= 4;
        }
    }
}