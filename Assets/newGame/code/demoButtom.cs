using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoButtom : MonoBehaviour {
    public closeupStage stage;
    public GameObject effect; 
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
    public void createEffect(GameObject gobj)
    {
        Debug.Log(gobj.name + "create effect");
        Instantiate(effect,gobj.transform.position,gobj.transform.rotation);
    }
    public void createEffects()
    {
        Debug.Log("createEffects !!!");
        foreach (BasicControler enermy in stage.team2)
        {
            GameObject rObj = enermy.GetComponent<roleAnim>().rootObj;
            Instantiate(effect, rObj.transform.position, rObj.transform.rotation);
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
        anim.forNextEffect += createEffects;
        anim.anim_attack(clearEnemyHitAnim);
    }
    public void onUnfightClick()
    {
        stage.uncloseUp();
        stage.setCurtain(false);
    }
}
