using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class roleAnim : MonoBehaviour {
    public const int BEHIT = 0;
    public const int ATTACK = 1;
    public const int MAGIC = 2;
    public const int DODGE = 3;

    public Animator anim;//手動拉取
    public SortingGroup sorter;
    protected SortingGroup hpbar_sorter;
    public state_test.withNothing forNextEffect;
    public delegate void withGameObject(GameObject gobj);
    public withGameObject forNextEffect_GOBJ;
    public state_test[] stateList;
    public GameObject rootObj;
    protected HpBar hpBar;
    public HpBar HpBar
    {
        set
        {
            hpBar = value;
            hpbar_sorter = hpBar.GetComponent<SortingGroup>();
            hpbar_sorter.sortingOrder = sorter.sortingOrder;
        }get
        {
            return hpBar;
        }
    }
    public int hpnum;
    //public withNothing onAttackEnd;
    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void goEffect()
    {
        Debug.Log("time to show effect");
        if (forNextEffect != null)
        {
            forNextEffect();
            
        }
        if (forNextEffect_GOBJ !=null)
        {
            forNextEffect_GOBJ(gameObject);
        }
        forNextEffect = null;
        forNextEffect_GOBJ=null;
    }
    public void endNowAnim()
    {
        foreach (state_test state in stateList)
        {
            if (state.stateActive)
            {
                state.force2End();
            }
        }
    }
    public void setRootObj(GameObject obj,int sortLayout)
    {
        rootObj = obj;
        anim = rootObj.GetComponent<Animator>();
        stateList = anim.GetBehaviours<state_test>();
        sorter = anim.GetComponent<SortingGroup>();
        setSortLayout(sortLayout);
    }


    public void anim_attack()
    {
        anim.SetBool("skill_1",true);
    }
    public void anim_attack(state_test.withNothing cb)
    {
        forNextEffect += cb;
        anim.SetBool("skill_1", true);
    }
    public void anim_magic()
    {
        anim.SetBool("skill_3", true);
    }
    public void anim_magic(state_test.withNothing cb)
    {
        forNextEffect += cb;
        anim.SetBool("skill_3", true);
    }
    public void anim_behit()
    {
        anim.SetBool("hit_1", true);
    }
    public void anim_behit(state_test.withNothing cb)
    {
        anim.GetBehaviour<state_behit>().forNextEnd += cb;
        anim.SetBool("hit_1", true);
    }
    public void anim_died()
    {
        anim.SetBool("death", true);
    }
    public void anim_dodge(state_test.withNothing cb)
    {
        anim.GetBehaviour<state_dodge>().forNextEnd += cb;
        anim.SetBool("jump", true);
    }
    public void addSortLayout(int layout)
    {
        sorter.sortingOrder+=layout;
        if(hpbar_sorter)
            hpbar_sorter.sortingOrder += layout;
    }
    public void setSortLayout(int layout)
    {
        sorter.sortingOrder = layout;
        if(hpbar_sorter)
            hpbar_sorter.sortingOrder = layout;
    }

    public void onHpChange(float percentage)
    {
        closeupStage.main.update_roleHp(this, percentage);
    }
    public void setHpBar(float percentage)
    {
        hpBar.Percentage = percentage;
    }
    //public 
}
