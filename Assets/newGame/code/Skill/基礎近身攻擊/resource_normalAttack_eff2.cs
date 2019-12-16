using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_normalAttack_eff2 : resource_normalAttack {
    public override string[] prafebList
    {
        get
        {
            return new string[1] { "effection/打擊效果2" };
        }
    }
    public override string ScriptName
    {
        get
        {
            return base.ScriptName+"_eff2";
        }
    }
}
