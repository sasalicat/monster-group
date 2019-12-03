using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class skill_resource : skill_representation {
    public abstract string Explanation { get; }
    public abstract string ScriptName { get; }
    public abstract string SkillName { get; }
    public abstract string[] prafebList { get; }//用來記錄這個技能會用到哪些prafeb的名字
    public GameObject[] resource=null;
    public virtual void init(unitData nowdata)
    {
        if (resource == null)
        {
            resource = new GameObject[prafebList.Length];
            for (int i = 0; i < prafebList.Length; i++)
            {
                resource[i] = (GameObject)Resources.Load(prafebList[i]);
            }
        }
    }
}
