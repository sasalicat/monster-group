using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : Environment {
    public const int MAX_UNIT_NUM = 40;
    public const int X = 5;
    public const int Y = 8;
    public unitControler[,] board=new unitControler[8,5];
    public unitControler[] units = new unitControler[MAX_UNIT_NUM];
    public bool enter(unitControler unit,int pos_x,int pos_y)
    {
        if (board[pos_y, pos_x] != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public unitControler[] Units
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }


}
