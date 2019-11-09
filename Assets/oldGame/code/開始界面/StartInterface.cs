using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInterface : MonoBehaviour {
    public GameObject buttom1;
    public GameObject buttom2;
    public GameObject buttem3;
	// Use this for initialization
	void Start () {
		//buttom1.beforeTrans +=
        buttom1.GetComponent<transScene>().beforeTrans += dataWarehouse.main.createNewArchive;
        buttom2.GetComponent<transScene>().beforeTrans += dataWarehouse.main.loadArchive;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
