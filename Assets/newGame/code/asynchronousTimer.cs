using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asynchronousTimer : Timer {
    public float max_time_perframe=0.005f;
    public int max_counter_perframe = 100;
    public int frameNumber = 0;
    protected void Update()
    {

        float start_time = Time.realtimeSinceStartup;
        for(int i = 0; i < max_counter_perframe; i++)
        {
            frameNumber++;
            callAllFunction(1f);//0.01是隨便寫的數字,實際上這個版本的update根本不關心間隔是多久
            if(Time.realtimeSinceStartup - start_time > max_time_perframe)
            {
                //Debug.LogWarning("時間耗盡跳出!耗時:"+(Time.realtimeSinceStartup - start_time)+"總計幀數:"+i);
                break;
            }
            Debug.Log("第"+frameNumber+"幀");
        }
        //Debug.LogWarning("完成100! 幀耗時:" + (Time.realtimeSinceStartup - start_time));
    }
}
