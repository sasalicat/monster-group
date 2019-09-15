using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInf  {
    public const string TAG_DAMAGE = "damage";
    public const string TAG_CONTROL = "control";
    public const string TAG_CURE = "cure";
    public const string TAG_BUFF = "buff";
    public const string TAG_NUFF = "nuff";
    public const string TAG_FIRE = "fire";
    public const string TAG_ICE = "ice";
    public const string TAG_THUNDER = "thunder";
    public const string TAG_HOLY = "holy";

    public bool attack;
    public bool singleTraget;
    public List<string> tags;
    public bool activeSkill;
    public bool remote = true;

    public static SkillInf passiveSkillInf()
    {
        return new SkillInf(false, false, false, new List<string>());
    }
    public SkillInf() {
        singleTraget = true;
        tags = new List<string>() { "damage" };
        activeSkill = false;
        attack = false;
    }
    public SkillInf(bool singleTraget,bool active,bool attack, List<string> tags)
    {
        this.singleTraget = singleTraget;
        this.activeSkill = active;
        this.attack = attack;
        this.tags = tags;
    }
    public SkillInf(bool singleTraget, bool active, bool attack,bool remote, List<string> tags)
    {
        this.singleTraget = singleTraget;
        this.activeSkill = active;
        this.attack = attack;
        this.tags = tags;
        this.remote = remote;
    }
}
