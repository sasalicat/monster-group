using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class substitutePanel : MonoBehaviour {
    public GameObject panel;
    public GameObject headPrafeb;
    public teamPanel girdControl;
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
        Vector2 s_LU = teamPanel.ScreenLeftUp();
        Vector2 s_RD = teamPanel.ScreenRightDown();
        float screen_up = s_LU.y;
        float screen_height = s_RD.y - s_LU.y;
        float screen_width = s_RD.x - s_LU.x;
        float screen_left = s_LU.x;
        float screen_right = s_RD.x;

        Vector2 team0_lu = new Vector2( screen_left,screen_up);
        Vector2 team0_rd = new Vector2(screen_right, screen_up + 0.4f * screen_height);
        Vector2 team1_lu = new Vector2(screen_left, screen_up + 0.4f * screen_height);
        Vector2 team1_rd = new Vector2(screen_right, screen_up + 0.8f * screen_height);
        //Debug.Log("camera width:"+width+" height:"+height);
        //Debug.Log("screen left up:"+teamPanel.ScreenLeftUp());
        //Debug.Log("screen right down:" + teamPanel.ScreenRightDown());
        girdControl.createGroup(null, new vec2i(5, 4), team0_lu, team0_rd);
        girdControl.createGroup(null, new vec2i(5, 4), team1_lu, team1_rd);
    }
    
    public void createHead(int race,List<int> skillNos,List<int> itemNos)
    {
        GameObject headIcon= Instantiate(headPrafeb, panel.transform);
        headIcon.transform.localPosition = new Vector2(x_start+ x_offset * heads.Count,y_pos);
        heads.Add(headIcon);
    }
}
