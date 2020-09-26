using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public abstract class skill_resource : skill_representation {
    public abstract string Explanation { get; }
    public abstract string ScriptName { get; }
    public abstract string SkillName { get; }
    public abstract string[] prafebList { get; }//用來記錄這個技能會用到哪些prafeb的名字
    //public GameObject[] resource=null;
    public abstract string IconName { get; }
    public static Dictionary<string, Sprite> IconPool = new Dictionary<string, Sprite>();
    public abstract modifier[] mods { get; }
    public virtual buff_Inf[] depends
    {
        get
        {
            return new buff_Inf[0];
        }
    }
    public virtual bool createPrafebOnInit {
        get
        {
            return true;
        }
    }
    /*public virtual string poolKey
    {
       get {
            return ScriptName;
        }
    }*/

    public virtual void init(unitData nowdata)
    {

        if (createPrafebOnInit)
        {
            foreach (string name in prafebList)
            {
                if (!dynamicSkill.resourcePool.ContainsKey(name))
                {
                    /*
                    resource = new GameObject[prafebList.Length];
                    for (int i = 0; i < prafebList.Length; i++)
                    {
                        resource[i] = (GameObject)Resources.Load(prafebList[i]);
                    }
                    dynamicSkill.resourcePool[ScriptName] = resource;*/
                    dynamicSkill.resourcePool[name] = (GameObject)Resources.Load(name);
                }
            }
        }
        if (!IconPool.ContainsKey(ScriptName))
        {
            //Debug.Log("type:"+ Resources.Load(IconName).GetType());
            IconPool[ScriptName] = (Sprite)Resources.Load<Sprite>(IconName);
        }
        //Debug.Log(typeof(skill_resource).ToString());
    }
}
