using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class dynamicSkill : CDSkill {
    //protected GameObject[] resources=null;
    protected List<modifier> modifierList;
    public static Dictionary<string, GameObject[]> resourcePool=new Dictionary<string, GameObject[]>();
    protected abstract List<modifier> Modifiers
    {
        get;
    }
    public abstract SkillInf Inf();
    public Damage_v2 createDamage(int num,byte kind,Dictionary<string,object> skillArg)
    {
        Damage_v2 d = new Damage_v2(num, kind, owner);
        d.extraArgs["blockDeny"] = (float)skillArg["blockDeny"];
        d.extraArgs["dodgeDeny"] = (float)skillArg["dodgeDeny"];
        d.extraArgs["critical"] = false;
        return d;
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        modifierList = Modifiers;
        this.owner = (BasicControler)owner;
        information = Inf();
        foreach(modifier mod in modifierList)
        {
            mod.traget = this;
            mod.onSkillInit(owner, deleg);
        }
        
    }
    /*
    public void setResources(GameObject[] resources)
    {
        this.resources = resources;
    }*/
    public abstract unitControler[] getTragets(Environment env);
    public override unitControler[] findTraget(Environment env)
    {
        unitControler[] tragets= getTragets(env);
        foreach (modifier mod in modifierList)
        {
            mod.onFindTraget(env,ref tragets);
        }
        return tragets;
    }
    public List<comboControler> getAliveEnemy(ChessBoard env)
    {
        List<comboControler> enemy=new List<comboControler>();
        foreach(comboControler control in env.units)
        {
            if (control.playerNo != owner.playerNo && !control.data.Dead)
            {
                enemy.Add(control);
            }
        }
        return enemy;
    }

}
