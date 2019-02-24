using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : Environment {
    protected int x = 5;
    protected int y = 8;
    protected int max_unit_num;
    public int X
    {
        get
        {
            return x;
        }
    }
    public int Y
    {
        get
        {
            return y;
        }
    }
    public unitControler[,] board;
    public List<unitControler> units;
    public ChessBoard(int x,int y)
    {
        this.x = x;
        this.y = y;
        this.max_unit_num = x * y;
        Debug.Log("初始化chess board");
        board = new unitControler[y, x];
        units = new List<unitControler>();
    }
    public bool enter(unitControler unit,int pos_x,int pos_y)
    {
        Debug.Log("pos_y:" + pos_y + ",pos_x" + pos_x);
        Debug.Log("board:" + board);
        if (board[pos_y, pos_x] != null)
        {
            return false;
        }
        else
        {
            board[pos_y, pos_x] = unit;
            return true;
        }
    }
    public List<unitControler> Units
    {
        get
        {
            return units;
        }

        set
        {
            units = value;
        }
    }


}
