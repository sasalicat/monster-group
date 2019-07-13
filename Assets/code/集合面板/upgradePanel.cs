using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class upgradePanel : MonoBehaviour {
    public GameObject skillInfPanel;//手動拉取
    public Image roleBox;//手動拉取
    public GameObject skillsPanel;//手動拉取
    public Text atribute;//手動拉取
	// Use this for initialization
    public void prepareRole(RoleRecord traget)
    {
        int no = traget.careers[traget.careers.Count - 1];
        roleBox.sprite = ImageList.main.headIcons[traget.race];
        string text = "";
        foreach()
    }
}
