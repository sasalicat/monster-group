using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blind_bInf : buff_Inf
{
    public string[] prafebNames
    {
        get
        {
            return new string[1] { "effection/致盲特效" };
        }
    }

    public string scriptName
    {
        get
        {
            return "newBuff_blind";
        }
    }
}
