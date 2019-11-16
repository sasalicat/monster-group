using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roleAnim : MonoBehaviour {
    public Animator anim;//手動拉取
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void anim_attack()
    {
        anim.SetBool("skill_1",true);
    }
    public void anim_magic()
    {
        anim.SetBool("skill_3", true);
    }
    public void anim_behit()
    {
        anim.SetBool("hit_1", true);
    }
    public void anim_died()
    {
        anim.SetBool("death", true);
    }
}
