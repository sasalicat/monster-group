using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class skill_criticalTemplate : Skill
{

    protected abstract int percentage{
        get;
    }
    protected abstract float multiple
    {
        get;
    }
    protected virtual int plus
    {
        get
        {
            return 0;
        }
    }
    protected virtual int kind{
        get {
            return Damage.KIND_PHYSICAL;
        }
    }
    void callback(Damage d)
    {
        Debug.LogWarning("skill_criticalTemplate callback");
   
        if (kind != Damage.KIND_PHYSICAL && kind != Damage.KIND_MAGICAL && kind != Damage.KIND_REAL)
        {
            int point = Randomer.main.getInt();
            if (point< percentage)
            {
                d.num = (int)(d.num* multiple);
                d.num += plus;
                if (!d.tag.Contains(Damage.TAG_CRITICAL))
                {
                    d.tag.Add(Damage.TAG_CRITICAL);
                }
            }
        }
        else
        {
            if (d.kind == kind)
            {//這個時候creater已經是traget了
                int point = Randomer.main.getInt();
                Debug.LogWarning("point= " + point);
                if (point < percentage)
                {
                    d.num = (int)(d.num * multiple);
                    d.num += plus;
                    if (!d.tag.Contains(Damage.TAG_CRITICAL))
                    {
                        d.tag.Add(Damage.TAG_CRITICAL);
                    }
                    Debug.LogWarning("觸發后傷害數量為:" + d.num);
                }
            }
        }
    }
    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        Debug.LogWarning("skill_criticalTemplate 初始化");
        information = new SkillInf(false, false, false, new List<string>());
        this.owner = (BasicControler)owner;
        deleg._befCauseDamage += callback;
    }
}
