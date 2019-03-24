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
    Dictionary<unitControler, int> unit2pos = new Dictionary<unitControler, int>();//從controler到flatten的索引
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
            units.Add(unit);
            unit2pos[unit] = pos_y * X + pos_x;
            return true;
        }
    }
    public int[] getPosFor(unitControler unit)
    {
        int flatten = unit2pos[unit];
        int y = flatten / X;
        int x = flatten % X;
        return new int[2] { x, y };
    }
    public unitControler[] unitsBehind(unitControler unit)
    {
        List<unitControler> list=new List<unitControler>();
        int[] pos = getPosFor(unit);
        if (pos[1] < Y / 2)
        {
            for (int y = pos[1] - 1; y >= 0; y--)
            {
                if (board[y, pos[0]] != null)
                {
                    list.Add(board[y, pos[0]]);
                }
            }
        }
        else {
            for(int y = pos[1] + 1; y < Y; y++)
            {
                if (board[y, pos[0]] != null)
                {
                    list.Add(board[y, pos[0]]);
                }
            }
        }
        return list.ToArray();
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
