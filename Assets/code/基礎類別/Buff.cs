using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Buff :MonoBehaviour {
    public delegate void withBuff(Buff buff);
    public withBuff onfail;
    public float TimeLeft
    {
        get
        {
            return timeLeft;
        }
    }
    public  float timeLeft=1;
    public unitControler unit;
    public abstract float Duration
    {
        get;
    }
    public int index;//位于buff阵列的索引
    public abstract bool onInit(unitControler unit, Buff[] Repetitive,Dictionary<string,object> args);//如果角色身上已经有相同buff存在了则Repetitive将不为null,Repetitive会回传所有相同的buff
    //onInit的回传值为是否添加,如果回传false,该buff会被删掉而不触发onRemove
    public virtual void onIntarvel(unitControler unit, float timeBetween)
    {
        //Debug.Log("buff timeLeft:" + timeLeft);
            timeLeft -= timeBetween;
            if (timeLeft <= 0)
            {
            //Debug.Log("觸發deleteSelf");
                deleteSelf();
            }
    }
    public abstract void onRemove();
    public void deleteSelf()
    {
        Debug.Log("deleteSelf");
        this.onRemove();
        onfail(this);
        Destroy(this);
    }
    void Start()
    {
        if (Duration > 0)
        {
            timeLeft = Duration;
        }
    }
}
