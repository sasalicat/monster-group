using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_v2 : Damage {
    public Dictionary<string, object> extraArgs;
    public Damage_v2(int num, byte kind, unitControler creater):base(num,kind,creater)
    {
        extraArgs = new Dictionary<string, object>();
    }
    public Damage_v2(int num, byte kind, unitControler creater, List<string> tags) : base(num, kind, creater, tags)
    {
        extraArgs = new Dictionary<string, object>();
    }

}
