using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Timer:MonoBehaviour{
    public delegate void onTimePass(float time);
    public static Timer main=null;
    protected onTimePass functions;

    public  void logInTimer(onTimePass function)
    {
        functions += function;
    }
    public void  loginOutTimer(onTimePass function)
    {
        functions -= function;
    }
    public void callAllFunction(float interval)
    {

        if (functions != null)
        {
            int len = functions.GetInvocationList().Length;
            Debug.Log("共" + len + "個function");
            functions(interval);
        }
    }
    protected void OnEnable()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
        Debug.Log("####Timer onEnable");
        functions = null;
    }
}

