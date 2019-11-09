using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class debugText : MonoBehaviour {
    public Text debugtext;
  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        string message = "";
        int roleNum = dataWarehouse.main.nowData.army.Count;
        for (int i = 0; i < roleNum; i++) {
            message += "roleRace:"+dataWarehouse.main.nowData.army[i].race+"\n";
        }
        debugtext.text = message;
        
	}
}
