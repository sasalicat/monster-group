using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillList : MonoBehaviour
{

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
    public List<int> MagicNos;
    public List<int> singleTragetMagicNo;
    public List<int> multipTragetMagicNo;
    public List<int> holyMagicNos;
    public List<int> holyHealingMagicNos;
    public List<int> holySupportMagicNos;
    
}
