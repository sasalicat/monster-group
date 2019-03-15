using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating : MonoBehaviour {
    public float ExistTime = 1f;
    public float timeLeft = 0f;
	// Use this for initialization
	void Start () {
        timeLeft = ExistTime;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
            Destroy(gameObject);
	}
}
