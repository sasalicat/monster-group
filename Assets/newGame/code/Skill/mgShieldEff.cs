using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mgShieldEff : switchEff, effTakeMsg
{
    public ParticleSystem particle;//手動拉取
    public Animator anim;//手動拉取
    public void takeMsg(string msg, object arg)
    {
        if(msg == "behit")
        {
            anim.SetBool("active", true);
        }
    }
    public void resetAnimKey()//給動畫事用的function,讓閃爍狀態能回到正常狀態
    {
        anim.SetBool("active", false);
    }
}
