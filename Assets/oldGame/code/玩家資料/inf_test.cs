using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inf_test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerInf data = new PlayerInf();
        data.army.Add(new RoleRecord(1));
        data.itemInBag.Add(0);
        data.itemInBag.Add(1);
        data.itemInBag.Add(5);
        data.printInf();
        data.saveInf();
        print("save file!");
        PlayerInf dataLoaded= PlayerInf.loadInf();
        print("load file!");
        dataLoaded.printInf();
        Debug.Log(dataLoaded.army.Count);
        Debug.Log(dataLoaded.army[0].race);
        //dataLoaded.

	}

}
