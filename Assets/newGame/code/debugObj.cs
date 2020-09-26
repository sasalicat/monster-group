using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.LogError(gameObject.name + "被產生!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
