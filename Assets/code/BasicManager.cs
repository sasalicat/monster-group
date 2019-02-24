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
    protected ChessBoard chessBoard;
    public unitControler createUnit(Dictionary<string, object> unitInf)
    {
        int posX = (int)unitInf["position_x"];
        int posY = (int)unitInf["position_y"];
        int unitNo = (int)unitInf["unit_no"];
        int playerNo = (int)unitInf["player_no"];
        List<int> skillnos = (List<int>)unitInf["skill_nos"];
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
        newone.GetComponent<SpriteRenderer>().sprite = ImageList.main.headIcons[unitNo];
        bool result = chessBoard.enter(controler, realX, realY);
        if (result)
        {
            GameObject hpbar= Instantiate(objectList.main.hpBar, newone.transform);
            controler.hpbar= hpbar.GetComponent<HpBar>();
            hpbar.transform.localPosition = objectList.main.hpBar.transform.position;
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
        Dictionary<string, object> testdata = new Dictionary<string, object>() { {STR_POS_X, 0 }, {STR_POS_Y,0}, { STR_UNIT_NO,1}, {STR_SKILL_NO, new List<int>()}, { STR_PLAYER_NO,1} };
        createUnit(testdata);
        Dictionary<string, object> testdata2 = new Dictionary<string, object>() { { STR_POS_X, 0 }, { STR_POS_Y, 0 }, { STR_UNIT_NO, 0 }, { STR_SKILL_NO, new List<int>() }, { STR_PLAYER_NO, 0 } };
        createUnit(testdata2);
        Dictionary<string, object> testdata3 = new Dictionary<string, object>() { { STR_POS_X, 0 }, { STR_POS_Y, 3 }, { STR_UNIT_NO, 0 }, { STR_SKILL_NO, new List<int>() }, { STR_PLAYER_NO, 0 } };
        createUnit(testdata3);
        Dictionary<string, object> testdata4 = new Dictionary<string, object>() { { STR_POS_X, 0 }, { STR_POS_Y, 1 }, { STR_UNIT_NO, 1 }, { STR_SKILL_NO, new List<int>() }, { STR_PLAYER_NO, 1 } };
        createUnit(testdata4);
        Dictionary<string, object> testdata5 = new Dictionary<string, object>() { { STR_POS_X, 0 }, { STR_POS_Y, 2 }, { STR_UNIT_NO, 1 }, { STR_SKILL_NO, new List<int>() }, { STR_PLAYER_NO, 1 } };
        createUnit(testdata5);
        Dictionary<string, object> testdata6 = new Dictionary<string, object>() { { STR_POS_X, 0 }, { STR_POS_Y, 3 }, { STR_UNIT_NO, 1 }, { STR_SKILL_NO, new List<int>() }, { STR_PLAYER_NO, 1 } };
        createUnit(testdata6);
        Dictionary<string, object> testdata7 = new Dictionary<string, object>() { { STR_POS_X, 0 }, { STR_POS_Y, 1 }, { STR_UNIT_NO, 0 }, { STR_SKILL_NO, new List<int>() }, { STR_PLAYER_NO, 0 } };
        createUnit(testdata7);
        Dictionary<string, object> testdata8 = new Dictionary<string, object>() { { STR_POS_X, 0 }, { STR_POS_Y, 2 }, { STR_UNIT_NO, 0 }, { STR_SKILL_NO, new List<int>() }, { STR_PLAYER_NO, 0 } };
        createUnit(testdata8);
    }

}
