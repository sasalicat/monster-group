using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicShield_bInf : buff_Inf
{
    public string[] prafebNames
    {
        get
        {
            return new string[1] { "effection/魔法盾-普通" };
        }
    }

    public string scriptName
    {
        get
        {
            return "newBuff_magicShield";
        }
    }
}
