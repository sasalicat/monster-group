using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state_dodge : state_atk {
    public GameObject gobj;
    public Vector2 backward = new Vector2(-2f, 0);
    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateMove(animator, stateInfo, layerIndex);
        if (!end)
        {
            float percentage = stateInfo.normalizedTime / stateInfo.length;
            gobj.transform.localPosition = backward * percentage;
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        gobj.transform.localPosition = Vector2.zero;
    }
}
