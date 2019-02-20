using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInf  {
    public const string TAG_DAMAGE = "damage";
    public const string TAG_CONTROL = "control";
    public const string TAG_CURE = "cure";
    public const string TAG_BUFF = "buff";
    public const string TAG_NUFF = "nuff"; 
    public bool singleTraget;
    public List<string> tags;
    public SkillInf() {
        singleTraget = true;
        tags = new List<string>() { "damage" };
   
    }
    public SkillInf(bool singleTraget, List<string> tags)
    {
        this.singleTraget = singleTraget;
        this.tags = tags;
    }
}
