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
            Debug.Log("basic ai 的 upate");
            ChessBoard map = (ChessBoard)env;
            int[] position = map.getPosFor(self);//拿到自己的坐標
            int posx = position[0];
            int posy = position[1];
            bool solve = false;
            if (((BasicControler)self).data.Remote)
            {
                if (((BasicControler)self).playerNo % 2 == 0)
                {
                    Debug.Log("path1");
                    for (int y = 4; y < 8; y++)//先判斷和自己同一行的角色
                    {
                        if (map.board[y, posx] != null && ((BasicControler)map.board[y, posx]).playerNo != 0)
                        {
                            ((BasicControler)self).traget = map.board[y, posx];
                            solve = true;
                            break;
                        }
                    }
                    //不行的話再從前到後依次掃描
                    for (int y = 4; y < 8; y++)
                    {
                        for (int x = 0; x < 5; x++)
                        {
                            if (map.board[y, x] != null && ((BasicControler)map.board[y, x]).playerNo != 0)
                            {
                                ((BasicControler)self).traget = map.board[y, x];
                                solve = true;
                                break;
                            }
                        }
                        if (solve)
                        {
                            break;
                        }
                    }
                }
                else if (((BasicControler)self).playerNo % 2 == 1)
                {
                    Debug.Log("path2");
                    for (int y = 3; y >= 0; y--)//先判斷和自己同一行的角色
                    {
                        if (map.board[y, posx] != null && ((BasicControler)map.board[y, posx]).playerNo != 1)
                        {
                            ((BasicControler)self).traget = map.board[y, posx];
                            solve = true;
                            break;
                        }
                    }
                    //不行的話再從前到後依次掃描
                    for (int y = 3; y >= 0; y--)
                    {
                        for (int x = 0; x < 5; x++)
                        {
                            if (map.board[y, x] != null && ((BasicControler)map.board[y, x]).playerNo != 1)
                            {
                                ((BasicControler)self).traget = map.board[y, x];
                                solve = true;
                                break;
                            }
                        }
                        if (solve)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                if (((BasicControler)self).playerNo % 2 == 0)
                {
                    Debug.Log("path3");
                    for (int y = 4; y < 8; y++)
                    {
                        for (int x = 0; x < 5; x++)
                        {
                            if (map.board[y, x] != null && ((BasicControler)map.board[y, x]).playerNo != 0)
                            {
                                ((BasicControler)self).traget = map.board[y, x];
                                solve = true;
                                break;
                            }
                        }
                        if (solve)
                        {
                            break;
                        }
                    }
                }
                else if (((BasicControler)self).playerNo % 2 == 1)
                {
                    Debug.Log("path4 objname:"+ ((BasicControler)self).gameObject.name);
                    for (int y = 3; y >= 0; y--)
                    {
                        for (int x = 0; x < 5; x++)
                        {
                            if (map.board[y, x] != null && ((BasicControler)map.board[y, x]).playerNo != 1)
                            {
                                ((BasicControler)self).traget = map.board[y, x];
                                solve = true;
                                break;
                            }
                        }
                        if (solve)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
