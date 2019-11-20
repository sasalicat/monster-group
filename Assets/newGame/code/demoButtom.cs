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
    public void clearEnemyHitAnim()
    {
        foreach (BasicControler enermy in stage.team2)
        {
            enermy.GetComponent<roleAnim>().endNowAnim();
        }
    }
    public void onFightClick()
    {
        stage.closeUp(closeupStage.CU_RIGHT_TOLEFT);
        stage.display_onStage(stage.team1[0], stage.team2);
        roleAnim anim= stage.team1[0].GetComponent<roleAnim>();
        foreach(BasicControler enermy in stage.team2)
        {
            anim.forNextEffect+= enermy.GetComponent<roleAnim>().anim_behit;
        }
        anim.anim_attack(clearEnemyHitAnim);
    }
    public void onUnfightClick()
    {
        stage.uncloseUp();
        stage.setCurtain(false);
    }
}
