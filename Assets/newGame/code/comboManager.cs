﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboManager : BasicManager {

    //public Vector3[] team1_pos;
    //public Vector3[] team2_pos;
    public ChessBoard ChessBoard
    {
        get {
            return chessBoard;
        }
    }
    public override ChessBoard createChessBoard()
    {
        return new ChessBoard(2, 6);
    }
    public override int PLAYER_NO
    {
        get
        {
            return 0;
        }
    }
    public override int ENEMY_NO
    {
        get
        {
            return 1;
        }
    }
    protected override void Start()
    {
        base.Start();
    }
    public override unitControler createUnit(Dictionary<string, object> unitInf) {
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
        GameObject newone = closeupStage.main.createRole(playerNo,posX,posY,inf.race);
        newone.name = "位於(" + realX + "," + realY + ")";
        Debug.Log("playerNo:" + playerNo + " chessx:" + chessBoard.X + " chessy:" + chessBoard.Y);
        //Debug.Log("realY")
        if (playerNo % 2 == 0)//user
        {
            realX = posX;
            realY = chessBoard.Y / 2 - 1 - posY;
        }
        else if (playerNo % 2 == 1)//敵人
        {
            realX = posX;
            realY = chessBoard.Y / 2 + posY;
        }
        //newone.transform.position = new Vector2(INIT_X + realX * X_INTERVAL, INIT_Y + realY * Y_INTERVAL);
        comboControler controler = newone.GetComponent<comboControler>();
        controler.playerNo = playerNo;
        //newone.GetComponent<SpriteRenderer>().sprite = ImageList.main.headIcons[unitNo];
        bool result = chessBoard.enter(controler, realX, realY);
        Debug.Log("result:" + result);
        if (result)
        {
            GameObject hpbar = Instantiate(objectList.main.hpBar, newone.transform);
            hpbar.transform.localPosition = objectList.main.hpBar.transform.position;
            hpbar.GetComponent<HpBar>().HpColor = playerColor[playerNo];
            //要複製一個新的unitData,不然在戰鬥中的技能可能會永久地改變角色屬性
            controler.init(new voidAI(), chessBoard, new unitData(data), hpbar.GetComponent<HpBar>());
            controler._onDeath = forRoleDeath;
            Timer.main.logInTimer(controler.action);
            newone.AddComponent<sp_effection>();
            SkillBelt belt = newone.AddComponent<SkillBelt>();
            controler.skillBelt = belt;
            belt.init(controler, skillnos);
            itemBelt item_belt = newone.AddComponent<itemBelt>();
            item_belt.init(controler, itemnos);
            return controler;
        }
        else
        {
            Destroy(newone);
            return null;
        }
        
        
    }
}