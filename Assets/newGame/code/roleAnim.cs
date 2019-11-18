using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class roleAnim : MonoBehaviour {
    public Animator anim;//手動拉取
    public SortingGroup sorter;
    // Use this for initialization
	void Start () {
		state_test[] list= anim.GetBehaviours<state_test>();
        foreach (state_test state in list)
        {
            //state
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void goEffect()
    {
        Debug.Log("time to show effect");
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
    public void addSortLayout(int layout)
    {
        sorter.sortingOrder+=layout;
    }
}
