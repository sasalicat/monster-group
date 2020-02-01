using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInf_v2 : SkillInf {
    public Skill skill;
    public bool canUseToDead=false;//可以對死亡單位使用,大部分技能都不能對死亡的單位使用,除了復活型技能或者帶有毀滅尸體的技能
    public const string TAG_HEAL = "heal";
    public SkillInf_v2(Skill self,bool singleTraget, bool active, bool attack, bool remote, List<string> tags):base(singleTraget,active,attack,remote,tags)
    {
        skill = self;
    }
    public SkillInf_v2(Skill self,bool singleTraget, bool active, bool attack, List<string> tags):base(singleTraget,active,attack,tags)
    {
        skill = self;
    }
    public SkillInf_v2(Skill self) : base()
    {
        skill = self;
    }
}