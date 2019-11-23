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
}
