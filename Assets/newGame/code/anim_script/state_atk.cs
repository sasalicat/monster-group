using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state_atk : state_test
{
    public withNothing forNextEnd;
    public override void onEnd(bool bySelf)
    {
        if(forNextEnd!=null)
            forNextEnd();
        forNextEnd = null;

    }
}
