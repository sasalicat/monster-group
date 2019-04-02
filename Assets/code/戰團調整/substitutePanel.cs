using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class substitutePanel : MonoBehaviour {
    public GameObject panel;
    public GameObject headPrafeb;
    List<GameObject> heads = new List<GameObject>();
    public const float x_start = 0.6f;
    public const float x_offset = 1f;
    public const float y_pos = 0.25f;
    protected float scale = 1;
	// Use this for initialization
	void Start () {
        createHead(0, null, null);
        createHead(1, null, null);
        createHead(2, null, null);
        int height = Camera.main.scaledPixelHeight;
        int width = Camera.main.scaledPixelWidth;
        Debug.Log("camera width:"+width+" height:"+height);
	}
    
    public void createHead(int race,List<int> skillNos,List<int> itemNos)
    {
        GameObject headIcon= Instantiate(headPrafeb, panel.transform);
        headIcon.transform.localPosition = new Vector2(x_start+ x_offset * heads.Count,y_pos);
        heads.Add(headIcon);
    }
}
