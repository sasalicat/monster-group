using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillList : MonoBehaviour {

    public static SkillList main = null;
    void OnEnable()
    {
        if (main != null)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }
    public List<string> representation;
    public Dictionary<int, List<string>> Substitute;
    public List<int> singleTragetMagicNo;
}
