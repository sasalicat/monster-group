﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asynchronousTimer : Timer {
    public float max_time_perframe=0.005f;
    public int max_counter_perframe = 100;
    protected void Update()
    {

        float start_time = Time.realtimeSinceStartup;
        for(int i = 0; i < max_counter_perframe; i++)
        {
            callAllFunction(0.01f);//0.01是隨便寫的數字,實際上這個版本的update根本不關心間隔是多久
            if(Time.realtimeSinceStartup - start_time > max_time_perframe)
            {
                break;
            }
        }
        //Debug.Log("完成100! 幀耗時:" + (Time.realtimeSinceStartup - start_time));
    }
}
