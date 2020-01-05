using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callbackHitEff : commonHitEff {
    missile.withMissile onEnd;
    public override void init(Dictionary<string, object> effDict, GameObject selfPrafeb)
    {
        base.init(effDict, selfPrafeb);
        onEnd += (missile.withMissile)effDict["callback"];
    }
    public void OnDestroy()
    {
        onEnd(null);
    }
}
