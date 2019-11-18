using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_movement {
    public enum move {SkillStart,SkillEnd,Anim,Effection,Missile,Number};
	// Use this for initialization
    public move order;
    public List<object> argList;
    public stage_movement(move order, List<object> argList)
    {
        this.order = order;
        this.argList = argList;
    }
}
