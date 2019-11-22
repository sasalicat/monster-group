using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state_test : StateMachineBehaviour
{
    public delegate void withNothing();
    public float stillStartTime = -1;
    public float stillTime = 0;
    public float speed_baseline = 5f;
    //float still_percentage = 0.2f;
    public float minSpeed = 0.15f;
    bool end = false;
    public bool stateActive
    {
        get
        {
            return !end;
        }
    }
    float oriAnimLength=1;
    Animator nowAnimator=null;
    public virtual void onEnd(bool endBySelf){
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log(animator.gameObject.name+":state_test OnStateEnter");
        //Debug.Log("length:" + stateInfo.length + "loop:" + stateInfo.loop + "normalizedTime:" + stateInfo.normalizedTime+"speed:"+stateInfo.speed);
        //Debug.Log("修改speed到:" + animator.speed);
        oriAnimLength = stateInfo.length;
        end = false;
        nowAnimator = animator;
        //stateInfo.speed = 2;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log(name+":state_test OnStateExit !!!!!!!!!!!!!!!!!!");
        animator.speed = 1;
        end = true;
        nowAnimator = null;
        onEnd(true);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log(name+":state_test OnStateUpdate");
    }
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log(name + ":state_test OnStateMove " + "length:" + stateInfo.length + "loop:" + stateInfo.loop + "normalizedTime:" + stateInfo.normalizedTime + "speed:" + stateInfo.speed);
        if (!end)
        {
            //Debug.Log("1-still_percentage:" + (1 - still_percentage) + "normalizedTime:" + stateInfo.normalizedTime);
            float time = (stateInfo.normalizedTime / oriAnimLength);
            if (stillStartTime >= 0) {
                time = (stateInfo.normalizedTime / stillStartTime);
            }
            
            if (time > 1)
            {
                time = 1;
            }
            float evalue = EasingFunction.EaseInCirc(1, 0, time);
            //Debug.Log("time"+time+"eValue:"+evalue);
            float now_speed =evalue * speed_baseline;
            //Debug.Log("time:"+time+"evalue:"+evalue+ "now_speed:" + now_speed);
            if (now_speed < minSpeed)
            {
                now_speed = minSpeed;
            }
           animator.speed = now_speed;

            //Debug.Log();
        }
    }
    public void force2End()
    {
        end = true;
        if (nowAnimator != null)
        {
            nowAnimator.speed = 1;
            nowAnimator = null;
        }
        onEnd(false);
    }
}
