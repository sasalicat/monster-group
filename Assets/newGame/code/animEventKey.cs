using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animEventKey : MonoBehaviour {
    public Animator anim;
    public roleAnim father;
    void Start()
    {
        anim = GetComponent<Animator>();
        if (transform.parent != null)
        {
            father = transform.parent.GetComponent<roleAnim>();
        }
    }
    public void father_goEffect()
    {
        father.goEffect();
    }
    public void resetBack()
    {
        anim.SetBool("back",false);
    }

}
