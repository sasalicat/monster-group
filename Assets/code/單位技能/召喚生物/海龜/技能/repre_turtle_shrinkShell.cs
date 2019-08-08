using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repre_turtle_shrinkShell : skill_representation
{
    public string Explanation
    {
        get
        {
            return "我縮!";
        }
    }

    public string ScriptName
    {
        get
        {
            return "skill_turtle_shrinkShell";
        }
    }

    public string SkillName
    {
        get
        {
            return "縮殼";
        }
    }

    public void init(unitData nowdata)
    {

    }
}
