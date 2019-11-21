using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decisionArea_stateEnd : decisionArea
{

	// Use this for initialization
	void Start () {
        Debug.Log("decisionArea_stateEnd Start!!! state_atk:" + GetComponent<Animator>().GetBehaviour<state_atk>());
        base.Start();
        GetComponent<Animator>().GetBehaviour<decision_state>().onAnimEnd += DestroySelf;
	}
}
