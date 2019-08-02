using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicManager : MonoBehaviour,Manager {
    public const float INIT_X = -1.83f;
    public const float INIT_Y = 3.75f;
    public const float X_INTERVAL = 0.91f;
    public const float Y_INTERVAL = -1.1f;
    public const string STR_POS_X = "position_x";
    public const string STR_POS_Y = "position_y";
    public const string STR_UNIT_NO = "unit_no";
    public const string STR_PLAYER_NO = "player_no";
    public const string STR_SKILL_NO = "skill_nos";
    public const string STR_INF = "information";


    protected ChessBoard chessBoard;
    protected Dictionary<int, Color> playerColor = new Dictionary<int, Color>() { {0,Color.red}, { 1,Color.blue} };

    public GameObject failedPanel;//手動拉取
    public GameObject successPanel;//手動拉取

    public void forRoleDeath(GameObject gobj)
    {
        gobj.AddComponent<fadeOut>();
        BasicControler control = gobj.GetComponent<BasicControler>();
        int[] coor=  chessBoard.getPosFor(control);
        chessBoard.removeAt(coor[0],coor[1]);
        Timer.main.loginOutTimer(control.action);
        int enemyCount = 0;
        int playerCount = 0;
        foreach(unitControler unit in chessBoard.units)
        {
            if(control == ((BasicControler)unit).traget)
            {
                Debug.LogWarning("control == ((BasicControler)unit).traget");
                ((BasicControler)unit).traget = null;
            }
            if (((BasicControler)unit).playerNo==0)
            {
                enemyCount += 1;
            }
            else if (((BasicControler)unit).playerNo == 1)
            {
                playerCount += 1;
            }
        }
        if(playerCount == 0)//只要全隊陣亡就輸了,就算同歸於盡也沒用
        {
            TimerDriver.main.pause = true;
            failedPanel.SetActive(true);
            return;
        }
        if (enemyCount == 0) {//勝利
            TimerDriver.main.pause = true;
            successPanel.SetActive(true);
            successPanel.GetComponent<rewardPanel>().init(dataWarehouse.main.levelReward);
        }

        
    }
    public unitControler createUnit(Dictionary<string, object> unitInf)
    {
        Debug.Log("創建新的單位");
        int posX = (int)unitInf["position_x"];
        int posY = (int)unitInf["position_y"];

        RoleRecord inf = ((RoleRecord)unitInf["information"]);
        int unitNo = inf.race;
        int playerNo = (int)unitInf["player_no"];
        List<int> skillnos = inf.skillNos;
        List<int> itemnos = inf.itemNos;
        unitData data = inf.data;
        int realX = 0;
        int realY = 0;
        GameObject newone = Instantiate(objectList.main.mainUnit);
        newone.name = "隨機"+UnityEngine.Random.Range(0, 100);
        Debug.Log("playerNo:" + playerNo+" chessx:"+chessBoard.X+" chessy:"+chessBoard.Y);
        //Debug.Log("realY")
        if(playerNo%2 ==0)
        {
            realX = posX;
            realY = chessBoard.Y/2-1 - posY;
        }
        else if (playerNo%2 == 1)
        {
            realX = posX;
            realY = chessBoard.Y/2 + posY;
        }
        newone.transform.position = new Vector2(INIT_X + realX * X_INTERVAL, INIT_Y + realY * Y_INTERVAL);
        BasicControler controler= newone.AddComponent<BasicControler>();
        controler.playerNo = playerNo;
        newone.GetComponent<SpriteRenderer>().sprite = ImageList.main.headIcons[unitNo];
        bool result = chessBoard.enter(controler, realX, realY);
        Debug.Log("result:"+result);
        if (result)
        {
            GameObject hpbar= Instantiate(objectList.main.hpBar, newone.transform);
            hpbar.transform.localPosition = objectList.main.hpBar.transform.position;
            hpbar.GetComponent<HpBar>().HpColor = playerColor[playerNo];
            //要複製一個新的unitData,不然在戰鬥中的技能可能會永久地改變角色屬性
            controler.init(new BasicAI(),chessBoard,new unitData(data), hpbar.GetComponent<HpBar>());
            controler._onDeath = forRoleDeath;
            Timer.main.logInTimer(controler.action);
            newone.AddComponent<sp_effection>();
            SkillBelt belt= newone.AddComponent<SkillBelt>();
            controler.skillBelt = belt;
            belt.init(controler, skillnos);
            itemBelt item_belt = newone.AddComponent<itemBelt>();
            item_belt.init(controler, itemnos);
            //是否要用字串來儲存技能名?
            return controler;
        }
        else
        {
            Destroy(newone);
            return null;
        }
        
        
    }

    public void HandleOrder(Dictionary<string, object> order)
    {
        
    }

    // Use this for initialization
    void Start () {
        chessBoard = new ChessBoard(5,8);
        PlayerInf playdata = dataWarehouse.main.nowData;
        foreach(RoleRecord unit in playdata.army){
            if (unit.location != null)
            {
                Dictionary<string, object> unitDic = new Dictionary<string, object>() { { STR_POS_X, unit.location.x }, { STR_POS_Y, unit.location.y }, { STR_PLAYER_NO, 1 }, { STR_INF, unit } };
                unitControler controler = createUnit(unitDic);
            }
        }
        List<RoleRecord> enemys = dataWarehouse.main.currentEnemy;
        foreach(RoleRecord enemy in enemys)
        {
            Dictionary<string, object> enemyDic = new Dictionary<string, object>() { { STR_POS_X, enemy.location.x }, { STR_POS_Y, enemy.location.y }, { STR_PLAYER_NO, 0 }, { STR_INF, enemy } };
            createUnit(enemyDic);
        }
        /*
        roleInformation inf = new roleInformation(new unitData(),new List<int>(){1,7},0);
        Dictionary<string, object> testdata = new Dictionary<string, object>() { { STR_POS_X, 0 }, { STR_POS_Y, 1 }, { STR_PLAYER_NO, 1 }, { STR_INF, inf} };
        unitControler controler = createUnit(testdata);
        ((BasicControler)controler).gameObject.name = "單位1";

        roleInformation inf3 = new roleInformation(new unitData(), new List<int>() { 0}, 2);
        Dictionary<string, object> testdata3 = new Dictionary<string, object>() { { STR_POS_X, 0 }, { STR_POS_Y, 2 }, { STR_PLAYER_NO, 1 }, { STR_INF, inf3 } };
        unitControler controler3 = createUnit(testdata3);
        ((BasicControler)controler3).gameObject.name = "單位3";

        roleInformation inf4 = new roleInformation(new unitData(), new List<int>() { 0 }, 2);
        Dictionary<string, object> testdata4 = new Dictionary<string, object>() { { STR_POS_X, 0 }, { STR_POS_Y, 3 }, { STR_PLAYER_NO, 1 }, { STR_INF, inf4 } };
        unitControler controler4 = createUnit(testdata4);
        ((BasicControler)controler4).gameObject.name = "單位4";

        roleInformation inf5 = new roleInformation(new unitData(), new List<int>() { 0,11 }, 2);
        Dictionary<string, object> testdata5 = new Dictionary<string, object>() { { STR_POS_X, 1 }, { STR_POS_Y, 1 }, { STR_PLAYER_NO, 1 }, { STR_INF, inf5 } };
        unitControler controler5 = createUnit(testdata5);
        ((BasicControler)controler5).gameObject.name = "單位5";
        //組1---------------------------------------------------------------------------------------------------
        roleInformation inf2 = new roleInformation(new unitData(), new List<int>() { 0, 13,14 }, 1);
        Dictionary<string, object> testdata2 = new Dictionary<string, object>() { { STR_POS_X, 0 }, { STR_POS_Y, 1 }, { STR_PLAYER_NO, 0 }, { STR_INF, inf2 } };
        unitControler controler2 = createUnit(testdata2);
        ((BasicControler)controler2).gameObject.name = "單位2";*/

        /*roleInformation inf6 = new roleInformation(new unitData(), new List<int>() { 0, 5, 6, 10 }, 1);
        Dictionary<string, object> testdata6 = new Dictionary<string, object>() { { STR_POS_X, 1 }, { STR_POS_Y, 1 }, { STR_PLAYER_NO, 0 }, { STR_INF, inf6 } };
        unitControler controler6 = createUnit(testdata6);
        ((BasicControler)controler6).gameObject.name = "單位6";*/
    }

}
