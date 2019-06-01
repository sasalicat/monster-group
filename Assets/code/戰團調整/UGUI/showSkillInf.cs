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
        panel.transform.position = transform.position;
        panel.SetActive(true);
        skillPanel sk_panel= panel.GetComponent<skillPanel>();
        sk_panel.SkillName = skillInf.SkillName;
        sk_panel.SkillIntroduce = skillInf.Explanation;
    }
    public void onMouseUp()
    {
        panel.SetActive(false);
    }
}
