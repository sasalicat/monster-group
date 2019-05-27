using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillPanel : MonoBehaviour {
    public Text skillName; //手動拉取
    public Text skillIntro;//手動拉取
    public string SkillName
    {
        set
        {
            skillName.text = value;
        }
    }
    public string SkillIntroduce
    {
        set
        {
            skillIntro.text = value;
        }
    }
}
