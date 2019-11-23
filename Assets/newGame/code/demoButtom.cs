using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoButtom : MonoBehaviour {
    public closeupStage stage;
    public GameObject effect; 
	// Use this for initialization
	void Start () {
        stage.team1 = new BasicControler[stage.team1_pos.Length];
		for(int i=0;i<stage.team1_pos.Length;i++)
        {
            Vector3 pos = stage.team1_pos[i];
            GameObject newrole= Instantiate(stage.rolePrefab, pos, stage.rolePrefab.transform.rotation);
            stage.team1[i] = newrole.GetComponent<comboControler>();
            newrole.GetComponent<roleAnim>().addSortLayout(100 + i);
        }
        stage.team2 = new BasicControler[stage.team2_pos.Length];
        for(int i = 0; i < stage.team2_pos.Length; i++)
        {
            Vector3 pos = stage.team2_pos[i];
            GameObject newrole = Instantiate(stage.rolePrefab, pos, Quaternion.Euler(0,0,0));
            stage.team2[i] = newrole.GetComponent<comboControler>();
            newrole.GetComponent<roleAnim>().setSortLayout(100 + i);
        }
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
        /*
        stage.closeUp(closeupStage.CU_RIGHT_TOLEFT);
        stage.display_onStage(stage.team1[0], stage.team2);
        roleAnim anim= stage.team1[0].GetComponent<roleAnim>();
        foreach(BasicControler enermy in stage.team2)
        {
            anim.forNextEffect+= enermy.GetComponent<roleAnim>().anim_behit;
            
        }
        anim.forNextEffect += createEffects;
        anim.anim_attack(clearEnemyHitAnim);*/
        demoSkill();
    }
    public void onUnfightClick()
    {
        //stage.uncloseUp();
        //stage.setCurtain(false);
        stage.recloseUp(closeupStage.CU_RIGHT_TOLEFT);
    }
    public void demoSkill()
    {
        List<unitControler> sk1_tgs = new List<unitControler>();
        sk1_tgs.Add(stage.team2[1]);
        sk1_tgs.Add(stage.team2[2]);
        sk1_tgs.Add(stage.team2[4]);
        stage.display_skill(stage.team1[0],null,sk1_tgs,false);
        stage.display_anim(stage.team1[0], roleAnim.ATTACK);
        stage.display_anim(stage.team2[1], roleAnim.BEHIT);
        stage.display_anim(stage.team2[2], roleAnim.BEHIT);
        stage.display_anim(stage.team2[4], roleAnim.BEHIT);
        List<unitControler> sk2_tgs = new List<unitControler>();
        sk2_tgs.Add(stage.team1[0]);
        sk2_tgs.Add(stage.team1[1]);
        stage.display_skill(stage.team2[1], null, sk2_tgs, true);
        stage.display_anim(stage.team2[1], roleAnim.ATTACK);
        stage.display_anim(stage.team1[0], roleAnim.BEHIT);
        stage.display_anim(stage.team1[1], roleAnim.BEHIT);
        stage.display_skillEnd();
        stage.display_skillEnd();

    }
}
