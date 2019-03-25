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
    public unitControler createUnit(Dictionary<string, object> unitInf)
    {
        Debug.Log("創建新的單位");
        int posX = (int)unitInf["position_x"];
        int posY = (int)unitInf["position_y"];
        roleInformation inf = ((roleInformation)unitInf["information"]);
        int unitNo = inf.raceNo;
        int playerNo = (int)unitInf["player_no"];
        List<int> skillnos = inf.skillNos;
        unitData data = inf.data;
        int realX = 0;
        int realY = 0;
        GameObject newone = Instantiate(objectList.main.mainUnit);
        Debug.Log("playerNo:" + playerNo+" chessx:"+chessBoard.X+" chessy:"+chessBoard.Y);
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

            controler.init(new BasicAI(),chessBoard,data, hpbar.GetComponent<HpBar>());
            Timer.main.logInTimer(controler.action);
            newone.AddComponent<sp_effection>();
            SkillBelt belt= newone.AddComponent<SkillBelt>();
            controler.skillBelt = belt;
            belt.init(controler, skillnos);

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
        roleInformation inf2 = new roleInformation(new unitData(), new List<int>() { 0, 5, 6, 10 }, 1);
        Dictionary<string, object> testdata2 = new Dictionary<string, object>() { { STR_POS_X, 0 }, { STR_POS_Y, 1 }, { STR_PLAYER_NO, 0 }, { STR_INF, inf2 } };
        unitControler controler2 = createUnit(testdata2);
        ((BasicControler)controler2).gameObject.name = "單位2";

        roleInformation inf6 = new roleInformation(new unitData(), new List<int>() { 0, 5, 6, 10 }, 1);
        Dictionary<string, object> testdata6 = new Dictionary<string, object>() { { STR_POS_X, 1 }, { STR_POS_Y, 1 }, { STR_PLAYER_NO, 0 }, { STR_INF, inf6 } };
        unitControler controler6 = createUnit(testdata6);
        ((BasicControler)controler6).gameObject.name = "單位6";
    }

}
