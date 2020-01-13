using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weak_bInf : buff_Inf
{
    public string[] prafebNames
    {
        get
        {
            return new string[1] { "effection/虛弱特效" };
        }
    }

    public string scriptName
    {
        get
        {
            return "newBuff_weak";
        }
    }
}

