using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : AI
{
    public void update(unitControler self,Environment env)
    {
        if (((BasicControler)self).traget == null)
        {
            ChessBoard map = (ChessBoard)env;
            int[] position = map.getPosFor(self);//拿到自己的坐標

        }
    }
}
