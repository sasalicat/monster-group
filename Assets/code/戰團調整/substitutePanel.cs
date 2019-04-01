using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class substitutePanel : MonoBehaviour {
    public GameObject panel;
    public GameObject headPrafeb;
    List<GameObject> heads = new List<GameObject>();
    public const float x_start = 0.8f;
    public const float x_offset = 1.5f; 
	// Use this for initialization
	void Start () {
        createHead(0, null, null);
        createHead(1, null, null);
        createHead(2, null, null);
	}

    public void createHead(int race,List<int> skillNos,List<int> itemNos)
    {
        GameObject headIcon= Instantiate(headPrafeb, panel.transform);
        headIcon.transform.localPosition = new Vector2(x_start+ x_offset * heads.Count,0);
        heads.Add(headIcon);
    }
}
