using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class assemblePoint : MonoBehaviour {
    public List<RoleRecord> forSold;
	// Use this for initialization
	void Start () {
        forSold.Add(careerList.main.randomRoleFor(2));
        forSold.Add(careerList.main.randomRoleFor(2));
        forSold.Add(careerList.main.randomRoleFor(2));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
