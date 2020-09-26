using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugTimer : MonoBehaviour {
    float startTime=0;
    bool stop = false;
    public Text txt;
    private void battleOver()
    {
        stop = true;
    }
    // Use this for initialization
    void Start () {
        startTime= Time.time;
        ((comboManager)comboManager.main).onAllDeath += battleOver;

    }
	
	// Update is called once per frame
	void Update () {
        if (!stop)
        {
            txt.text = "耗時:"+(Time.time - startTime);
        }
	}
}
