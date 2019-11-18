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
        stage.display_onStage(stage.team1[0], stage.team2);
        stage.team1[0].GetComponent<roleAnim>().anim_attack();
        foreach(BasicControler enermy in stage.team2)
        {
            enermy.GetComponent<roleAnim>().anim_behit();
        }
    }
    public void onUnfightClick()
    {
        stage.uncloseUp();
        stage.setCurtain(false);
    }
}
