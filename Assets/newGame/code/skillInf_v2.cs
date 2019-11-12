using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInf_v2 : SkillInf {
    public Skill skill;
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