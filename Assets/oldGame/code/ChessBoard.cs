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
    public unitControler removeAt(int pos_x,int pos_y)
    {
        unitControler unit = board[pos_y, pos_x];
        board[pos_y, pos_x] = null;
        units.Remove(unit);
        unit2pos.Remove(unit);
        return unit; 
    }
    public unitControler[] enemyOf(unitControler unit)
    {
        List<BasicControler> enemys = new List<BasicControler>();
        int[] pos = getPosFor(unit);
        if (pos[1] < Y / 2)
        {
            for (int y = Y / 2; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    if (board[y, x] != null)
                    {
                        enemys.Add((BasicControler)board[y, x]);
                    }
                }
            }

        }
        else
        {
            for (int y = 0; y < Y / 2; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    if (board[y, x] != null)
                    {
                        enemys.Add((BasicControler)board[y, x]);
                    }
                }
            }
        }
        return enemys.ToArray();
    }
    public unitControler[] teammateOf(unitControler unit)
    {
        List<BasicControler> teammate = new List<BasicControler>();
        int[] pos = getPosFor(unit);
        if (pos[1] < Y / 2)
        {
            for (int y = 0; y < Y / 2; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    if (board[y, x] != null)
                    {
                        teammate.Add((BasicControler)board[y, x]);
                    }
                }
            }
        }
        else {
            for (int y = Y/2; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    if (board[y, x] != null)
                    {
                        teammate.Add((BasicControler)board[y, x]);
                    }
                }
            }
        }
        return teammate.ToArray(); 
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
    public unitControler[] frontRowFor(unitControler unit)
    {
        List<unitControler> list = new List<unitControler>();
        int[] pos = getPosFor(unit);
        if (pos[1] < Y / 2)
        {
            for (int y = Y / 2 - 1; y >= 0; y--) {
                for(int x =0;x< X; x++)
                {
                    if (board[y, x] != null) {
                        list.Add(board[y, x]);
                    }
                }
                if(list.Count > 0)
                {
                    return list.ToArray();
                }
            }
        }
        else
        {
            for (int y = Y / 2; y <Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    if (board[y, x] != null)
                    {
                        list.Add(board[y, x]);
                    }
                }
                if (list.Count > 0)
                {
                    return list.ToArray();
                }
            }
        }
        return list.ToArray();
    }
    public unitControler[] getColOf(unitControler unit)
    {
        List<unitControler> list = new List<unitControler>();
        int[] pos = getPosFor(unit);
        Debug.Log("getPosFor:(" + pos[0]+","+pos[1]+")");
        int x = pos[0];
        if (pos[1] < Y / 2)
        {
            for (int y = Y / 2 - 1; y >= 0; y--)
            {
                if (board[y, x] != null)
                {
                    list.Add(board[y, x]);
                }
            }
        }
        else
        {
            for (int y = pos[1] + 1; y < Y; y++)
            {
                if (board[y, x] != null)
                {
                    list.Add(board[y, x]);
                }
            }
        }
        return list.ToArray();
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
    public unitControler[] getDist1Of(unitControler unit)
    {
        List<unitControler> list = new List<unitControler>();
        List<int[]> offsets = new List<int[]>() { new int[2]{0,1},new int[2] {0,-1},new int[2] {1,0},new int[2] {-1,0} };
        int[] pos = getPosFor(unit);
        foreach (int[] offset in offsets) {
            int x = pos[0] + offset[0];
            int y = pos[1] + offset[1];
            if (pos[1] < Y / 2)
            {
                if (y < Y / 2 && y >= 0 && x >= 0 && x < X)//在player0的範圍內
                {
                    if (board[y, x] != null)
                    {
                        list.Add(board[y, x]);
                    }

                }
            }
            else
            {
                if (y >= Y / 2 && y < Y && x >= 0 && x < X)//在player0的範圍內
                {
                    if (board[y, x] != null)
                    {
                        list.Add(board[y, x]);
                    }

                }
            }
        }
        return list.ToArray();
    }
    public unitControler[] getDist1Of(unitControler unit,bool containSource)
    {
        unitControler[] results = getDist1Of(unit);
        if (containSource){
            List<unitControler> list = new List<unitControler>() {unit};
            foreach(unitControler control in results)
            {
                list.Add(control);
            }
            results = list.ToArray();
        }
        return results;
    }
    public unitControler[] get3by3Of(unitControler unit)
    {
        List<unitControler> list = new List<unitControler>();
        int[] pos = getPosFor(unit);
        for(int y = pos[1] - 1; y <= pos[1] + 1; y++)
        {
            for(int x = pos[0] - 1; x <= pos[0] + 1; x++)
            {
                if(pos[1] < Y / 2)
                {
                    if (y < Y / 2 && y >= 0 && x >= 0 && x < X)//在player0的範圍內
                    {
                        if (board[y, x] != null) {
                            list.Add(board[y,x]);
                        }

                    }
                }
                else
                {
                    if (y >= Y / 2 && y <Y && x >= 0 && x < X)//在player0的範圍內
                    {
                        if (board[y, x] != null)
                        {
                            list.Add(board[y, x]);
                        }

                    }
                }

            }
        }
        return list.ToArray();
        
    }
    public unitControler[] get3by3Of(unitControler unit,bool containSource)
    {
        if (!containSource)
        {
            List<unitControler> list = new List<unitControler>();
            int[] pos = getPosFor(unit);
            for (int y = pos[1] - 1; y <= pos[1] + 1; y++)
            {
                for (int x = pos[0] - 1; x <= pos[0] + 1; x++)
                {
                    if (pos[1] < Y / 2)
                    {
                        if (y < Y / 2 && y >= 0 && x >= 0 && x < X)//在player0的範圍內
                        {
                            if (board[y, x] != null && board[y,x] != unit)
                            {
                                list.Add(board[y, x]);
                            }

                        }
                    }
                    else
                    {
                        if (y >= Y / 2 && y < Y && x >= 0 && x < X)//在player0的範圍內
                        {
                            if (board[y, x] != null && board[y, x] != unit)
                            {
                                list.Add(board[y, x]);
                            }

                        }
                    }

                }
            }
            return list.ToArray();
        }
        else {
            return get3by3Of(unit);
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
    public List<unitControler> getTeamOf(int playerNo)
    {
        List<unitControler> team = new List<unitControler>();
        foreach(BasicControler unit in units)
        {
            if(unit.playerNo == playerNo)
            {
                team.Add(unit);
            }
        }
        return team;
    }
}
