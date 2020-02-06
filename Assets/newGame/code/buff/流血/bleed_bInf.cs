using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bleed_bInf : buff_Inf
{
    public string[] prafebNames
    {
        get
        {
            return new string[1] { "effection/暫定流血效果" };
        }
    }

    public string scriptName
    {
        get
        {
            return "newBuff_bleed";
        }
    }
}
