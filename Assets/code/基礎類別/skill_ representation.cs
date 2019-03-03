using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface skill_representation  {
    string ScriptName
    {
        get;
    }
    string SkillName
    {
        get;
    }
    string Explanation
    {
        get;
    }
    /*SkillInf information
    {
        get;
    }*/
    void init(unitData nowdata);

}
