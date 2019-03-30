using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareerTable : MonoBehaviour {
    public Career[] table;
    public int MAX_SIZE = 20;
    public static CareerTable main = null;
    void OnEnable()
    {
        if (main != null)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }
    // Use this for initialization
    void Start () {
        table = new Career[MAX_SIZE];
        table[0] = new race_Orc();
        table[1] = new race_DarkElf();
        table[2] = new race_Troll();
        table[3] = new career_Warior_LV1();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
