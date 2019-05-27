using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showSkillInf : MonoBehaviour {
    private skill_representation skillInf;
    public GameObject panel;
    public void initInf(string name,unitData data)
    {
        skillInf = (skill_representation)System.Activator.CreateInstance(System.Type.GetType(name));
        skillInf.init(data);
    }
    public void onMouseDown()
    {
       
    }
}
