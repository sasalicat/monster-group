using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicDelegate {
    public delegate void withNone();
    public delegate void withInt(int i);
    public delegate void withFloat(float f);
    public delegate void withDamage(Damage d);
    public delegate void withGameObject(GameObject gobj);
    public delegate void withIntAndControler(int i,unitControler unit);
    public delegate void withHealMsg(HealMsg message);
    public delegate void forSkill(SkillInf skillInf, Dictionary<string, object> skillArgs);
    public delegate void forRefSkillTrageting(SkillInf skillInf, Dictionary<string, object> skillArgs,ref unitControler[] tragets);
    public delegate void forSkillTrageting(SkillInf skillInf, Dictionary<string, object> skillArgs, unitControler[] tragets);
    public delegate void withBuffAndControler(Buff buff, unitControler unit);
}
