using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamPanel : MonoBehaviour {
    protected List<RoleRecord> units = null;
    public List<GameObject> girds;
    public void init(List<RoleRecord> units, vec2i size)
    {
        this.units = units;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
