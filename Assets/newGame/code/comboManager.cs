using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboManager : BasicManager {

    public Vector3[] team1_pos;
    public Vector3[] team2_pos;
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
        GameObject newone = Instantiate(objectList.main.mainUnit);
        newone.name = "隨機" + UnityEngine.Random.Range(0, 100);
        Debug.Log("playerNo:" + playerNo + " chessx:" + chessBoard.X + " chessy:" + chessBoard.Y);
        //Debug.Log("realY")
        if (playerNo % 2 == 0)
        {
            realX = posX;
            realY = chessBoard.Y / 2 - 1 - posY;
        }
        else if (playerNo % 2 == 1)
        {
            realX = posX;
            realY = chessBoard.Y / 2 + posY;
        }
        newone.transform.position = new Vector2(INIT_X + realX * X_INTERVAL, INIT_Y + realY * Y_INTERVAL);
        BasicControler controler = newone.AddComponent<BasicControler>();
        controler.playerNo = playerNo;
        newone.GetComponent<SpriteRenderer>().sprite = ImageList.main.headIcons[unitNo];
        bool result = chessBoard.enter(controler, realX, realY);
        Debug.Log("result:" + result);
        if (result)
        {
            GameObject hpbar = Instantiate(objectList.main.hpBar, newone.transform);
            hpbar.transform.localPosition = objectList.main.hpBar.transform.position;
            hpbar.GetComponent<HpBar>().HpColor = playerColor[playerNo];
            //要複製一個新的unitData,不然在戰鬥中的技能可能會永久地改變角色屬性
            controler.init(new BasicAI(), chessBoard, new unitData(data), hpbar.GetComponent<HpBar>());
            controler._onDeath = forRoleDeath;
            Timer.main.logInTimer(controler.action);
            newone.AddComponent<sp_effection>();
            SkillBelt belt = newone.AddComponent<SkillBelt>();
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
}
