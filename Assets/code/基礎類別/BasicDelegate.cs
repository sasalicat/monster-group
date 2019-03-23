using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicDelegate {
    public delegate void withNone();
    public delegate void withInt(int i);
    public delegate void withDamage(Damage d);
    public delegate void forSkill(SkillInf skillInf, Dictionary<string, object> skillArgs);
    public delegate void forSkillTrageting(SkillInf skillInf, Dictionary<string, object> skillArgs, unitControler[] tragets);
}
