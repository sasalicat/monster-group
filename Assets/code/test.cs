using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        skillTest obj = gameObject.AddComponent<skillTest>();
        Debug.Log(obj.GetComponentsInParent(obj.GetType()));
        Component coms = obj.GetComponentInParent(System.Type.GetType("CDSkill"));
        Debug.Log(coms);
	}

}
