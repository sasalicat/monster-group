using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Vector2.zero);
        //Debug.Log("右下角位置為:" + pos);
        pos.z = 0;
        transform.position = pos;
        int pw = Camera.main.pixelWidth;
        int ph = Camera.main.pixelHeight;
        //Debug.Log("pixel width:" + pw + " pixel height:" + ph);
        float pixel2unit = Camera.main.orthographicSize;
        //Debug.Log("pixel to unit:" + pixel2unit*2);
        Vector3 posrt = Camera.main.ScreenToWorldPoint(new Vector2(pw, ph));
        RectTransform rect = GetComponent<RectTransform>();
        Debug.Log("rectangle:"+rect.rect);
        Vector3 scale = new Vector3((posrt.x - pos.x)/rect.rect.width,(posrt.y - pos.y)/rect.rect.height,1);
        transform.localScale = scale;
        //Debug.Log("右上角位置為:" + posrt);

    }
    public void onPanelQuit() {
        gameObject.SetActive(false);
    }
}
