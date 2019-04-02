using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelFix : MonoBehaviour {
    public Vector2 center = new Vector2(0,0);
    public int panelWidth;
    public int panelHeigth;
    public GameObject panel;
    public GameObject debugSphere;
    public static float getScale(float sprite_aspect,Vector2 sprite_size)
    {
        if (sprite_aspect > Camera.main.aspect)//如果圖片比較寬,就使圖片的長度對齊攝像機長度
        {
            float cameraHeight = Camera.main.orthographicSize * 2;
            return cameraHeight / sprite_size.y;

        }
        else
        {//如果圖片比較窄,就使圖片的寬度對齊攝像機寬度
            float cameraWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
            return cameraWidth / sprite_size.x;
        }
    }
    void Start()
    {
        Debug.Log(panel.GetComponent<SpriteRenderer>().sprite.bounds.size);
        float camare_aspect = Camera.main.aspect;
        //float camare_aspect = (float)Camera.main.pixelWidth / (float)Camera.main.scaledPixelHeight;
        //Debug.Log("相機比例:" + camare_aspect);
        Sprite sprite = panel.GetComponent<SpriteRenderer>().sprite;
        float sprite_aspect = sprite.bounds.size.x / sprite.bounds.size.y;
        //Debug.Log("圖片比例:" + sprite_aspect);
        float scale =1;
        if (sprite_aspect > camare_aspect)//如果圖片比較寬,就使圖片的長度對齊攝像機長度
        {
            float cameraHeight = Camera.main.orthographicSize * 2;
            scale = cameraHeight / sprite.bounds.size.y;

        }
        else {//如果圖片比較窄,就使圖片的寬度對齊攝像機寬度
            float cameraWidth = Camera.main.orthographicSize * 2*camare_aspect;
            scale = cameraWidth / sprite.bounds.size.x;
        }
        panel.transform.localScale = new Vector2(scale, scale);
        Vector3 cameraCenter = new Vector3(Camera.main.pixelWidth*0.5f, Camera.main.scaledPixelHeight*0.5f, 10);
        //Debug.Log("camera center:"+cameraCenter);
        panel.transform.position = Camera.main.ScreenToWorldPoint(cameraCenter)-(Vector3)center;
        //Debug.Log("trans zero" + Camera.main.ScreenToWorldPoint(Vector3.zero));
        //Debug.Log("trans center" + Camera.main.ScreenToWorldPoint(cameraCenter));
    }

}
