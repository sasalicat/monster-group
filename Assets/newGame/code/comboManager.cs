using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboManager : BasicManager {

    //public Vector3[] team1_pos;
    //public Vector3[] team2_pos;
    public BasicDelegate.withNone onAllDeath;
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
    protected virtual void onInit()
    {
        List<RoleRecord> enemy = new List<RoleRecord>();
        RoleRecord_v2 enemy1 = new RoleRecord_v2(0);
        enemy1.skillNos = new List<int>() {0,22};
        enemy1.location = new vec2i(1, 1);
        enemy.Add(enemy1);
        RoleRecord_v2 enemy2 = new RoleRecord_v2(0);
        //((unitData_v2)enemy2.data).Now_Dodge_Point = 400;
        enemy2.skillNos = new List<int>() {0};
        enemy2.location = new vec2i(2, 1);
        enemy.Add(enemy2);
        RoleRecord_v2 enemy3 = new RoleRecord_v2(0);
        //((unitData_v2)enemy3.data).Now_Dodge_Point = 400;
        enemy3.skillNos = new List<int> { 0 };
        enemy3.location = new vec2i(2, 0);
        enemy.Add(enemy3);
        dataWarehouse.main.currentEnemy=enemy;
        transform.position = new Vector3(0, 0, 0);
        
    }
    protected override void Start()
    {
        onInit();
        base.Start();
        /*
        var armys= chessBoard.getTeamOf(0);
        Debug.LogWarning("army 有" + armys.Count + "人");
        var enemys = chessBoard.getTeamOf(1);
        Debug.LogWarning("enemys 有" + enemys.Count + "人");
        Dictionary<string, object> arg = new Dictionary<string, object>();
        var binf = new weak_bInf();
        dynamicSkill.resourcePool[binf.prafebNames[0]] = (GameObject)Resources.Load(binf.prafebNames[0]);
        arg["time"] = unitData_v2.BASE_ABILITY_NUMBER * 20f;
        arg["layer"] = 4;
        closeupStage.main.display_extraStart();
        armys[0].addBuff("weak_bInf", arg);
        closeupStage.main.display_extraEnd();*/
    }
    public override unitControler createUnit(Dictionary<string, object> unitInf) {
        Debug.Log("創建新的單位");
        int posX = (int)unitInf["position_x"];
        int posY = (int)unitInf["position_y"];

        RoleRecord_v2 inf = ((RoleRecord_v2)unitInf["information"]);
        int unitNo = inf.race;
        int playerNo = (int)unitInf["player_no"];
        List<int> skillnos = inf.skillNos;
        List<int> itemnos = inf.itemNos;
        unitData_v2 data = (unitData_v2)inf.data;
        int realX = 0;
        int realY = 0;
        GameObject newone = closeupStage.main.createRole(playerNo,posX,posY,inf.race);
        
        //Debug.Log("realY")
        if (playerNo % 2 == 0)//user
        {
            realX = chessBoard.X-1-posY;
            realY = chessBoard.Y / 2 - 1 - posX;
        }
        else if (playerNo % 2 == 1)//敵人
        {
            realX = chessBoard.X - 1 - posY;
            realY = chessBoard.Y/2 + posX;
        }
        //newone.transform.position = new Vector2(INIT_X + realX * X_INTERVAL, INIT_Y + realY * Y_INTERVAL);
        newone.name = "team" + playerNo + "位於(" + realX + "," + realY + ")";
        Debug.Log("playerNo:" + playerNo + " chessx:" + chessBoard.X + " chessy:" + chessBoard.Y);
        comboControler controler = newone.GetComponent<comboControler>();
        controler.playerNo = playerNo;
        //newone.GetComponent<SpriteRenderer>().sprite = ImageList.main.headIcons[unitNo];
        bool result = chessBoard.enter(controler, realX, realY);
        Debug.Log("result:" + result);
        if (result)
        {
            
            //要複製一個新的unitData,不然在戰鬥中的技能可能會永久地改變角色屬性
            controler.init(new voidAI(), chessBoard, new unitData_v2(data));
            controler._onDeath = forRoleDeath;
            closeupStage.main.initNewRole(newone);
            Timer.main.logInTimer(controler.action);
            newone.AddComponent<sp_effection>();
            SkillBelt_v2 belt = newone.AddComponent<SkillBelt_v2>();
            controler.skillBelt = belt;
            belt.init(controler, skillnos);
            //controler.counterSkill = 
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
   
    public override void forRoleDeath(GameObject gobj)
    {
        //Debug.LogWarning(">>>>>"+gobj+"死亡");
        comboControler control = gobj.GetComponent<comboControler>();
        Timer.main.loginOutTimer(control.action);
        closeupStage.main.display_anim(control,AnimCodes.DEATH);
        unitControler[] teammates=(unitControler[])chessBoard.teammateOf(control);
        bool allDead = true;
        foreach (comboControler teammate in teammates)
        {
            if (!teammate.data.Dead)
            {
                allDead = false;
                break;
            }
        }
        if (allDead)
        {
            closeupStage.main.display_uncloseUp();
            if (onAllDeath!=null)
                onAllDeath();
        }
    }
}
