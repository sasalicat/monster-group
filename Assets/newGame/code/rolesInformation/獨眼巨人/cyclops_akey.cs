using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyclops_akey : animKeyDict
{
    protected override Dictionary<int, string> createDict()
    {
        Dictionary<int, string> newDict = new Dictionary<int, string>();
        //newDict[animCod]
        newDict[AnimCodes.ATTACK] = "skill_1";
        newDict[AnimCodes.MAGIC] = "skill_3";
        newDict[AnimCodes.BEHIT] = "hit_1";
        newDict[AnimCodes.DODGE] = "jump";
        newDict[AnimCodes.DEATH] = "death";
        return newDict;
    }
}
