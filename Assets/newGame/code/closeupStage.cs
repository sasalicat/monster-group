﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public struct closeAndPos
{
    Vector3 oriPos;
    Vector3 closePos;
    unitControler role;
    float nowTime;
    float totalTime;
    public bool end;
    public const float BASE_MOVE_TIME = 0.3f;
    public closeAndPos(bool value)
    {
        oriPos = Vector3.zero;
        closePos = Vector3.zero;
        role = null;
        nowTime = -1;
        totalTime = -1;
        end = value;
    }
    public closeAndPos(unitControler unit,Vector3 ori,Vector3 traget,float time)
    {
        role = unit;
        oriPos = ori;
        closePos = traget;
        totalTime = time;
        nowTime = 0;
        end = false;
    }
    public Vector3 moveStep(float interval)
    {
        Vector3 dir = closePos- oriPos;
        nowTime += interval;
        if (nowTime >= totalTime)
        {
            nowTime = totalTime;
            end = true;
        }
        return oriPos + dir * (nowTime/totalTime);
    }
    public void resetRole()
    {
        if(role!=null)
            ((comboControler)role).transform.position = oriPos;
    }
}
public class closeupStage : MonoBehaviour, battleStage
{

    public const int CU_RIGHT_TOLEFT = 0;
    public const int CU_LEFT_TORIGHT = 1;
    public const int CU_RIGHT_ONLY = 2;
    public const int CU_LEFT_ONLY = 3;
    public const int CU_NOCU = 4;
    public const int BASE_ROLE_LAYOUT = 100;
    public const int CURTAIN_MASKER_NUMBER = 101;
    protected enum cu_state {no_cu,cu_ing,cu_ed};//標記當前鏡頭的closeUp狀態
    public delegate void clock(float time);
 //   public delegate object with_movement(stage_movement move);
    public delegate void with_skillpackage(stage_movement move,skillpackage skp);
    public delegate void with_nothing();
    public GameObject cameraObj;
    public Vector3 camera_closeUp_right2left = new Vector3(-2.76f, -2.33f, -4.46f);
    public Vector3 camera_closeUp_left2right = new Vector3(2.76f, -2.33f, -4.46f);
    public Vector3 camera_normal = new Vector3(0.6f, -1.21f, -8.27f);
    public Vector3 camera_right_only =new Vector3(4f,-2.4f,-4.07f);
    public Vector3 camera_left_only = new Vector3(-4f,-2.4f,-4.07f);
    public Vector3 camera_now_traget = new Vector3(0,0,0);
    public Vector3 camera_uncloseup_begin;
    public int closeUpState = 0;
    public float closeUp_time = 0.3f;
    public float reCloseUpWait_time = 0.5f;
    protected float timeBefore = 0;
    public clock clockFunc;
    public clock onUpdateFunc;
    public Vector3[] team1_pos= new Vector3[6];
    public Vector3[] team1_closePoint;
    //public BasicControler[] team1;
    public roleAnim[] team1_anim= new roleAnim[6];
    public Vector3[] team2_pos=new Vector3[6];
    public roleAnim[] team2_anim=new roleAnim[6];
    public Vector3[] team2_closePoint;
    Dictionary<unitControler, roleAnim> controler2roleAnim = new Dictionary<unitControler, roleAnim>();
    //public BasicControler[] team2;
    public SpriteRenderer curtain;
    public float curtain_max_alph = 0.85f;

    //public GameObject rolePrefab;
    public GameObject createRole(int team,int x, int y,int prefabIndex)
    {
        Vector3 pos = Vector3.zero;
        if(team == 0)
        {
            pos = team1_pos[3 * y + x];
        }
        else if(team == 1)
        {
            pos = team2_pos[3 * y + x];
        }
        else
        {
            return null;
        }
        GameObject newRole = Instantiate(((objectNameList)objectList.main).mainUnit, pos, Quaternion.Euler(0, 0, 0));
        GameObject prafeb = ((objectNameList)(objectList.main)).getRolePrafeb(prefabIndex); //Instantiate(objectList.main.mainUnit);
        GameObject newone = Instantiate(prafeb, newRole.transform.position, Quaternion.Euler(0, 0, 0),newRole.transform);
        
        if (team == 0) {
            team1_anim[x * y + x] = newRole.GetComponent<roleAnim>();
            team1_anim[x * y + x].setRootObj(newone,BASE_ROLE_LAYOUT+x*y+x);
            
        }
        if (team == 1)
        {
            team2_anim[x * y + x] = newRole.GetComponent<roleAnim>();
            team2_anim[x * y + x].setRootObj(newone, BASE_ROLE_LAYOUT + x * y + x);
            newone.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
       
        return newRole;
    }
    public void initNewRole(GameObject newRole)
    {
        GameObject hpbar = Instantiate(objectList.main.hpBar, newRole.transform);
        hpbar.transform.localPosition = objectList.main.hpBar.transform.position;
        hpbar.GetComponent<HpBar>().HpColor = Color.red;
        roleAnim ranim = newRole.GetComponent<roleAnim>();
        ranim.HpBar = hpbar.GetComponent<HpBar>();
        comboControler controler = newRole.GetComponent<comboControler>();
        controler2roleAnim[controler] = newRole.GetComponent<roleAnim>();
        ((unitData_v2)controler.data)._onHpPercentageChange += ranim.onHpChange;
        //hpbar.GetComponent<SpriteRenderer>().sortingOrder = ranim.sorter.sortingOrder;
    }
    protected cu_state Cstate=cu_state.no_cu;
    private int[] CU_table;
    public closeAndPos nowClosePos=new closeAndPos(true);
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
        Vector3 cam_offset = camera_now_traget - camera_uncloseup_begin;//camera_normal;
        cameraObj.transform.position = camera_uncloseup_begin + (timeBefore / closeUp_time) * cam_offset;
        Color c= curtain.color;
        c.a = (timeBefore / closeUp_time)*curtain_max_alph;
        curtain.color = c;
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
        Color c = curtain.color;
        c.a = ((closeUp_time-timeBefore)*curtain_max_alph/ closeUp_time);
        curtain.color = c;
    }
    protected void reCloseUp_process(float time)
    {
        timeBefore += time;
        if (timeBefore < closeUp_time)//歸位鏡頭
        {
            Cstate = cu_state.cu_ing;
            Vector3 cam_offset = camera_normal - camera_uncloseup_begin;
            cameraObj.transform.position = camera_uncloseup_begin + (timeBefore / closeUp_time) * cam_offset;
            Debug.Log("stage1 timeBefore:" + timeBefore + " campos:" + cameraObj.transform.position);
            Color c = curtain.color;
            c.a = ((closeUp_time - timeBefore) * curtain_max_alph / closeUp_time);
            curtain.color = c;
        }
        else if (timeBefore < closeUp_time + reCloseUpWait_time)//等待階段
        {
            Debug.Log("stage2 timeBefore:" + timeBefore + " campos:" + cameraObj.transform.position);
            Cstate = cu_state.no_cu;
        }
        else if (timeBefore < closeUp_time * 2 + reCloseUpWait_time)//再次特寫
        {
            Cstate = cu_state.cu_ing;
            Vector3 cam_offset = camera_now_traget - camera_normal;
            cameraObj.transform.position = camera_normal + ((timeBefore- closeUp_time- reCloseUpWait_time) / closeUp_time) * cam_offset;
            //Debug.Log("stage3 timeBefore:" + timeBefore + " campos:" + cameraObj.transform.position);
            Color c = curtain.color;
            c.a = ((timeBefore - closeUp_time - reCloseUpWait_time) / closeUp_time) * curtain_max_alph;
            curtain.color = c;
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
        //stage_movement newone = new stage_movement(stage_movement.move.Number, new List<object>() { who, number, kind });
        floatNum_action newone = new floatNum_action(new List<object>() {who,number,kind});
        heap[0].argList.Add(newone);
    }
    public void display_floatingText(unitControler who,int code)
    {
        floatText_action newone = new floatText_action(new List<object>() {who,code});
        heap[0].argList.Add(newone);
    }
    public void display_recloseUp(int code)
    {
        List<object> list = new List<object> { code };
        stage_movement newone = new recloseUp_action(list);
        heap[0].argList.Add(newone);
    }
    public void display_closeUp(int code)
    {
        List<object> list = new List<object> { code };
        stage_movement newone = new closeUp_action(list);
        heap[0].argList.Add(newone);
    }
    private int testFaction(unitControler tester,List<unitControler> betesteds)//測試tester和betesteds的陣營關係
    {
        bool same=false;
        bool different = false;
        foreach(comboControler btd in betesteds)
        {
            if(((comboControler)tester).playerNo == btd.playerNo)
            {
                same = true;
            }
            else
            {
                different = true;
            }
        }
        if (same && different)
        {
            return 2;//betesteds既有友方又有敵方
        }
        else if (same)
        {
            return 1;//只有友方
        }
        else if (different)
        {
            return 0;//只有敵方
        }
        else {
            return -1;//betesteds為空
        }
    }
    private List<comboControler> getDomain(unitControler protagonist,int testcode)
    {
        comboManager manager = ((comboManager)BasicManager.main);
        List<comboControler> domain = new List<comboControler>() {  };
        ChessBoard env = ((comboManager)comboManager.main).ChessBoard;
        if (testcode == 2) {
            foreach(comboControler unit in env.units)
            {
                domain.Add(unit);
            }
        }
        else if(testcode == 1)
        {
            if (((comboControler)protagonist).playerNo == 0) {
                foreach (comboControler unit in env.units)
                {
                    if(unit.playerNo == 0)
                        domain.Add(unit);
                }
            }
            else if (((comboControler)protagonist).playerNo == 1)
            {
                foreach (comboControler unit in env.units)
                {
                    if (unit.playerNo == 1)
                        domain.Add(unit);
                }
            }
        }
        else if (testcode == 0) {
            domain.Add((comboControler)protagonist);
            if (((comboControler)protagonist).playerNo == 0)
            {
                foreach (comboControler unit in env.units)
                {
                    if (unit.playerNo == 1)
                        domain.Add(unit);
                }
            }
            else if (((comboControler)protagonist).playerNo == 1)
            {

                    foreach (comboControler unit in env.units)
                    {
                        if (unit.playerNo == 0)
                            domain.Add(unit);
                    }
                
            }
        }
        return domain;
    }
    public void display_skill(unitControler protagonist, Skill skill, List<unitControler> tragets, bool isTrigger)
    {
        Debug.Log(isTrigger+"技能使用者:" + ((comboControler)protagonist).name + " 目標:");
        foreach(unitControler traget in tragets)
        {
            Debug.Log("目標:" + ((comboControler)traget).name);
        }
        skill_movement before = heap[0];
        heap.Insert(0, new skill_movement(stage_movement.move.SkillStart, new List<object>(), protagonist, tragets, before.user, new List<unitControler>(before.tragets.ToArray())));
        heap[0].isTrigger = isTrigger;
        display_onStage(protagonist,tragets);
        bool close = true;
        if (skill == null)
        {
        }
        else {
            if (skill.information.remote)
            {
                close = false;
            }
        }
        heap[0].Close = close;
        if (!heap[0].isTrigger)//如果不是觸發的技能,說明是正牌技能
        {//確定domain
            /*heap[0].nowDomain = new List<comboControler>() { (comboControler)protagonist };
            foreach (comboControler unit in tragets)
            {
                heap[0].nowDomain.Add(unit);
            }*/
            if (close)
            {
                display_closeMoving(protagonist, tragets);
            }
            int testCode = testFaction(protagonist, tragets);
            int closeUp_code = CU_table[CU_table.Length / 2 * ((BasicControler)protagonist).playerNo+ testCode];//playerNo=0代表是右方的角色,=1代表的是左邊的角色
            display_recloseUp(closeUp_code);
            heap[0].nowDomain = getDomain(protagonist, testCode);
        }
        else {//觸發型技能
            bool redomain = false;
            if (!heap[1].nowDomain.Contains((comboControler)protagonist)) {
                redomain = true;
            }
            else
            {
                foreach (comboControler unit in tragets) {
                    if (!heap[1].nowDomain.Contains(unit))
                    {
                        redomain = true;
                        break;
                    }
                }
            }
            if (redomain)
            {
                display_closeMoving(protagonist, tragets);
                int testCode = testFaction(protagonist, tragets);
                int closeUp_code = CU_table[((int)CU_table.Length / 2) * ((BasicControler)protagonist).playerNo + testCode];
                display_closeUp(closeUp_code);
                heap[0].nowDomain = getDomain(protagonist, testCode);

            }
            else {
                heap[0].nowDomain = heap[1].nowDomain;//繼承上一個技能的domain
            }
        }
    }
    public void display_skillEnd()
    {
        stage_movement nowMove = heap[0];
        heap.RemoveAt(0);
        heap[0].argList.Add(nowMove);
        if (heap[0].Close)
        {
            //for()
        }

    }
    public void display_closeMoving(unitControler protagonist, List<unitControler> tragets)
    { 
        Vector3 cpos =getClosePos(tragets);
        Debug.Log("近戰位置:" + cpos + " 當前位置:"+ ((BasicControler)protagonist).transform.position);
        Vector3 oripos = getOriginPos(protagonist);
        heap[0].argList.Add(new toClosePos_action(new List<object>() { protagonist, cpos, oripos,closeAndPos.BASE_MOVE_TIME}));
        //heap[0].argList.Add(new resetClosePos_action(null));
    }
    //public void display_resetCloseMoving
    public void display_anim(unitControler unit, int code)
    {
        if (code== roleAnim.BEHIT)
        {
            heap[0].argList.Add(new animBenhit_action(new List<object>() {unit,code}));
        }
        else if(code == roleAnim.ATTACK||code == roleAnim.MAGIC)
        {
            heap[0].argList.Add(new animSkill_action( new List<object>() { unit, code }));
        }
        else if(code == roleAnim.DODGE)
        {
            heap[0].argList.Add(new animDodge_action(new List<object>() { unit, code }));
        }
        //heap[0].argList.Add(new stage_movement(stage_movement.move.Anim, new List<object>() { unit, code }));
    }
    public void display_onStage(unitControler unit,List<unitControler> tragets)
    {
        heap[0].argList.Add(new onstage_action(new List<object>() { unit, tragets }));
    }
    public void update_roleHp(roleAnim role,float percentage)
    {
        //Debug.LogWarning("update_roleHp被呼叫");
        heap[0].argList.Add(new hpBarUpdate_action(new List<object>() { role, percentage }));
    }
    //-------------------------------------------
    public void closeUp(int kind)
    {
        camera_uncloseup_begin = cameraObj.transform.position;
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
            case CU_LEFT_ONLY:
            {
                    camera_now_traget = camera_right_only;
                break;
            }
            case CU_RIGHT_ONLY:
                {
                    camera_now_traget = camera_left_only;
                    break;
                }
            case CU_NOCU:
                {
                    camera_now_traget = camera_normal;
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
    public void recloseUp(int kind,with_nothing end_cb)
    {
        recloseUp(kind);
        next_closeUpEnd += end_cb;
    }
    public Vector3 getClosePos(List<unitControler> roles) {
        List<int[]> posList = new List<int[]>();
        ChessBoard cbd = ((comboManager)BasicManager.main).ChessBoard;
        foreach (unitControler role in roles) {
            int[] pos = cbd.getPosFor(role);
            posList.Add(pos);
        }
        bool enemy = false;
        if (posList[0][1]>= (cbd.Y / 2))
        {
            enemy = true;
        }
        int forwardX = cbd.Y / 2 - 1;//設定最前目標的x,一開始是2,當找到一個在其之前的目標時設為該目標的x
        bool row1 = false;
        bool row2 = false;
        foreach (int[] pos in posList)
        {
            if (enemy)
            {
                if (pos[1]<(cbd.Y / 2))
                {
                    Debug.LogError("錯誤的close pos請求,有不同陣營的角色");
                    return Vector3.zero;
                }
                int posX = pos[1] - cbd.Y/2;
                if (posX < forwardX)
                {
                    forwardX = posX;
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
                if (pos[1] >= (cbd.Y / 2)) {
                    Debug.LogError("錯誤的close pos請求,有不同陣營的角色");
                    return Vector3.zero;
                }
                int posX = cbd.Y / 2 - 1 - pos[1];
                if (posX < forwardX)
                {
                    forwardX = posX;
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
            int teamLen = team2_anim.Length / 2;
            if (row1 && row2)
            {
                return (team2_closePoint[forwardX] + team2_closePoint[forwardX + teamLen]) / 2;
            }
            else if (row1)
            {
                return team2_closePoint[forwardX];
            }
            else if (row2)
            {
                return team2_closePoint[forwardX+teamLen];
            }
            else
            {
                Debug.LogError("錯誤的位置既不是row1也不是row2");

            }
        }
        else {
            int teamLen = team1_anim.Length / 2;
            if (row1 && row2)
            {
                return (team1_closePoint[forwardX] + team1_closePoint[forwardX + teamLen]) / 2;
            }
            else if (row1)
            {
                return team1_closePoint[forwardX ];
            }
            else if (row2)
            {
                return team1_closePoint[forwardX+teamLen];
            }
            else
            {
                Debug.LogError("錯誤的位置既不是row1也不是row2");

            }
        }
        return new Vector3(0,0,0);
    }
    int[] teamAndPos(int[] cb_pos,ChessBoard cbd)
    {
        int[] result = new int[3];
        //ChessBoard cbd = ((comboManager)BasicManager.main).ChessBoard;
        if (cb_pos[1] >= cbd.Y / 2)//敵人
        {
            result[0] = 1;
            result[1] =  cb_pos[1] - cbd.Y/2;
            result[2] =  cbd.X-1- cb_pos[0];
        }
        else {
            result[0] = 0;
            result[1] = cbd.Y / 2 - 1 - cb_pos[1];
            result[2] = cbd.X - 1 - cb_pos[0];
        }
        return result;
    }
    public Vector3 getOriginPos(unitControler unit)
    {
        ChessBoard cbd = ((comboManager)BasicManager.main).ChessBoard;
        int[] pos =  cbd.getPosFor(unit);
        int[] team_pos = teamAndPos(pos,cbd);
        if (team_pos[0] == 0)
        {
            return team1_pos[3 * team_pos[2] + team_pos[1]];
        }
        else if (team_pos[1] == 1)
        {
            return team2_pos[3 * team_pos[2] + team_pos[1]];
        }
        return Vector3.zero;
    }
    /*
    public void setCurtain(bool torf)
    {
        curtain.SetActive(torf);
    }*/
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
        CU_table = new int[6] { CU_LEFT_TORIGHT, CU_LEFT_ONLY, CU_NOCU,CU_RIGHT_TOLEFT,CU_RIGHT_ONLY,CU_NOCU};//用來查表closeup的動作
        
        //handleFuncs[(int)stage_movement.move.SkillStart] = SkillStart_for;
    }

    // Update is called once per frame
    void Update()
    {
        if (clockFunc != null)
        {
            clockFunc(Time.deltaTime);
        }
        if (onUpdateFunc!=null)
        {
            onUpdateFunc(Time.deltaTime);
        }
            //if (((skill_movement)rootMovement.argList[0]).nowState == stage_movement.state.unActive)
            if (packages.Count ==0)//如果沒有skillpackage
            {
                if (rootMovement.argList.Count > 0)//還有skill_movement需要處理
                {
                //handleFuncs[(int)stage_movement.move.SkillStart]((skill_movement)rootMovement.argList[0]);
                    //則解析目前的第一個skill_movement
                   if(!(rootMovement.argList[0] is skill_movement)){
                     Debug.LogWarning("type:" + rootMovement.argList[0].GetType());    
                   }
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
    public void onStage(unitControler actioner, unitControler[] tragets)
    {
        //setCurtain(true);
        for(int i=0;i<team1_anim.Length;i++)
        {
            roleAnim ranim = team1_anim[i];
            if(ranim!=null)
                ranim.setSortLayout(BASE_ROLE_LAYOUT + i);
        }
        for (int i = 0; i < team2_anim.Length; i++)
        {
            roleAnim ranim = team2_anim[i];
            if(ranim!=null)
                ranim.setSortLayout(BASE_ROLE_LAYOUT + i);
        }
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
        if (!nowpackage.now_movement.isTrigger)//強制復位近戰位置角色
        {
            resetClosePos_action special_reset = new resetClosePos_action(null);
            special_reset.onLoad(skpList[skpList.Count - 1]);
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
    public skill_movement now_movement;
    public List<object>[] stage_conditions;
    public skillpackage_func[] stage_funcs;
    

    public override void Next(object arg)//這個Next是用於stage2 missile擊通知,和stage3所有角色的被擊動畫完成通知
    {
        bool condition_meet = false;

        stage_conditions[stage].Remove(arg);
        if (stage_conditions[stage].Count == 0)
            {
                condition_meet = true;
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
        if (stage<0||stage_conditions[stage].Count == 0)
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
    public skillpackage(stage_movement movement)
        : base(movement)
    {
        now_movement = (skill_movement)movement;
        bool isTrigger = ((skill_movement)movement).isTrigger;
        stage_funcs = new skillpackage_func[5];
        stage_conditions = new List<object>[4];
        for(int i = 0; i < stage_conditions.Length; i++)
        {
            stage_conditions[i] = new List<object>();
        }
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