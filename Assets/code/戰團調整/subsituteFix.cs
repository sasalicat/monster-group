using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subsituteFix : MonoBehaviour {
    public Sprite sprite;
    public GameObject panel;
	// Use this for initialization
	void Start () {
        Debug.Log("屏幕左下為:" + Camera.main.ScreenToWorldPoint(new Vector2(0, 0)));
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, 0,10));
        float screen_width = Camera.main.orthographicSize * Camera.main.aspect * 2;
        float sprite_width = sprite.bounds.size.x;
        float scale_x = screen_width/sprite_width;
        transform.localScale = new Vector2(scale_x,transform.localScale.y);
        panel.transform.localScale = new Vector2(1 / scale_x, 1 / transform.localScale.y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
