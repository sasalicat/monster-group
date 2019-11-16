using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoButtom : MonoBehaviour {
    public closeupStage stage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void onFightClick()
    {
        stage.closeUp();
        stage.team1[0].GetComponent<roleAnim>().anim_attack();
        foreach(GameObject enermy in stage.team2)
        {
            enermy.GetComponent<roleAnim>().anim_behit();
        }
    }
    public void onUnfightClick()
    {
        stage.uncloseUp();
        
    }
}
