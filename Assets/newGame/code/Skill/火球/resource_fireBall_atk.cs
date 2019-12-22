using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource_fireBall_atk : resource_fireBall {
    public override modifier[] mods
    {
        get
        {
            return new modifier[2] { new mod_1_activeSkill(),new mod_1_attackReduceCD(0.6f) };
        }
    }
}
