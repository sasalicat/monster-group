using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_beastPartner : Skill
{
    public int[] toRelativePos(int[] pos,int playerNo,ChessBoard board)
    {
        if (pos.Length != 2)
        {
            return null;
        }
        if (playerNo % 2 == 0)
        {
            pos[1] = board.Y / 2 - pos[1];
        }
        else {
            pos[1] = pos[1] - board.Y / 2;
        }
        return pos;
    } 
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        information = SkillInf.passiveSkillInf();
        //BasicManager.main.createUnit()
    }
    public override void onEnvReady(Manager manager)
    {
        int index= Randomer.main.getInt();
        //index = index % creatureList.main.names.Count; 
        index = 2;
        RoleRecord data= creatureList.main.getObjectIn(index);
        BasicManager bm = (BasicManager)manager;
        int[] pos = ((ChessBoard)owner.env).getPosFor(owner);
        Dictionary<string, object> unitDic = null;
        ChessBoard cb = ((ChessBoard)owner.env);
        List<int[]> emptyList = new List<int[]>();
        if (owner.playerNo % 2 == 0)
        {
            if (pos[1] < 3) {
                if (cb.board[pos[1] + 1, pos[0]] == null) {
                    int[] tragetpos = new int[] { pos[0], pos[1] + 1 };
                    pos = toRelativePos(tragetpos, owner.playerNo,cb);
                    unitDic = new Dictionary<string, object>() { { BasicManager.STR_POS_Y, pos[1]}, { BasicManager.STR_POS_X, pos[0] }, { BasicManager.STR_PLAYER_NO, owner.playerNo }, { BasicManager.STR_INF, data } };

                }
            }
            if (unitDic == null)
            {
                for (int x = 0; x < cb.X; x++)
                {
                    for (int y = 0; y < cb.Y / 2; y++)
                    {
                        if (cb.board[y, x] == null)
                        {
                            emptyList.Add(new int[2] { x, y });
                        }
                    }
                }
            }
        }
        else
        {
            if (pos[1] >4)
            {
                if (cb.board[pos[1] -1, pos[0]] == null)
                {
                    int[] tragetpos = new int[] { pos[0], pos[1] -1 };
                    pos = toRelativePos(tragetpos, owner.playerNo, cb);
                    unitDic = new Dictionary<string, object>() { { BasicManager.STR_POS_Y, pos[1] }, { BasicManager.STR_POS_X, pos[0] }, { BasicManager.STR_PLAYER_NO, owner.playerNo }, { BasicManager.STR_INF, data } };
                }
            }
            if (unitDic == null)
            {
                for (int x = 0; x < cb.X; x++)
                {
                    for (int y = cb.Y/2; y < cb.Y; y++)
                    {
                        if (cb.board[y, x] == null)
                        {
                            emptyList.Add(new int[2] { x, y });
                        }
                    }
                }
            }
        }
        if(unitDic == null) {
            int posidx = Randomer.main.getInt() % emptyList.Count;
            pos = emptyList[posidx];
            pos = toRelativePos(pos, owner.playerNo, cb);
            unitDic = new Dictionary<string, object>() { { BasicManager.STR_POS_Y, pos[1] }, { BasicManager.STR_POS_X, pos[0] }, { BasicManager.STR_PLAYER_NO, owner.playerNo }, { BasicManager.STR_INF, data } };
        }
        Debug.Log("創建單位x:"+unitDic[BasicManager.STR_POS_X]+",y:"+unitDic[BasicManager.STR_POS_Y]);
        bm.createUnit(unitDic);
    }
}
