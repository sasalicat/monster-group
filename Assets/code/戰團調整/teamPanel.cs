using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamPanel : MonoBehaviour {
    protected List<RoleRecord> units = null;
    public List<GameObject> girds;
    public float scale;
    public float gapPercentage = 0.0f;//間隔在畫面中的百分比
    public void createGroup(List<RoleRecord> units,vec2i matric,Vector2 leftUp,Vector2 rightDown){
        Vector2 startPoint;
        float width = rightDown.x - leftUp.x;
        float height =leftUp.y -rightDown.y;
        float gapSize = 0;
        float girdSize = 0;
        float fieldAspect = width / height;
        float girdAspect = matric.x / matric.y; //(float)(girdSize.x) / (float)girdSize.y;
        float unitPixel = girds[0].GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        float spriteSize = girds[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        if (fieldAspect > girdAspect)
        {
            Vector2 boundWidth = new Vector2((width - height) / 2, 0);
            startPoint = leftUp + boundWidth;
            gapSize = (height * gapPercentage) / (matric.y + 1);
            girdSize = (height * (1 - gapPercentage) / matric.y);
        }
        else {
            startPoint = leftUp;
            gapSize = width * gapPercentage / (matric.x + 1);
            girdSize = width * (1 - gapPercentage) / matric.x;
        }
        Vector2 gapVec = new Vector2(gapSize, -gapSize);
        Vector2 halfGridVec = new Vector2(girdSize / 2, -girdSize / 2);
        float gScale = girdSize / spriteSize;
        Debug.Log("girdSize:" + girdSize + " spriteSize:" + spriteSize + "gscale:" + gScale);
        for (int y = 0; y < matric.y; y++)
        {
            for (int x = 0; x < matric.x; x++)
            {
                Vector2 pos = startPoint + new Vector2(x * (gapSize + girdSize), -y * (gapSize + girdSize)) + halfGridVec + gapVec;

                GameObject g = createGrid(pos, gScale, y * matric.x + x);
                g.name = "gird" + x + "-" + y;
            }
        }
    }
    public void init(List<RoleRecord> units, vec2i size)
    {
        this.units = units;
        Vector2 startPoint;
        float gapSize = 0;
        float girdSize = 0;
        float fieldAspect = Camera.main.pixelWidth / (0.5f * Camera.main.pixelHeight);
        float girdAspect = (float)size.x / (float)size.y;
        float unitPixel = girds[0].GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        float spriteSize = girds[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float cameraHeight_half = Camera.main.orthographicSize;
        float cameraWidth_half = Camera.main.orthographicSize * Camera.main.aspect;
        Debug.Log("field Asp:" + fieldAspect);
        Debug.Log("gird Asp" + girdAspect);
        Debug.Log("cameraWidth_half:" + cameraWidth_half);
        Debug.Log("cameraHeight_half:" + cameraHeight_half);
        if (fieldAspect > girdAspect)
        {

            int boundWidth = (int)(Camera.main.pixelWidth - 0.5f * Camera.main.pixelHeight);

            startPoint = Camera.main.ScreenToWorldPoint(new Vector2(0,Camera.main.pixelHeight*0.5f));
            Debug.Log("boundWidth:" + boundWidth + " screen space start position:" + new Vector2(boundWidth, Camera.main.pixelHeight * 0.5f) + " world space start position:" + startPoint);
            gapSize = (cameraHeight_half * gapPercentage / (size.y + 1));
            Debug.Log("gapSize:" + gapSize);
            girdSize = (cameraHeight_half *  (1-gapPercentage) / size.y);
            Debug.Log("girdSize:" + girdSize);
        }
        else
        {
            startPoint = Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight * 0.5f));
            Debug.Log("start point:"+startPoint+"camera width half:"+cameraWidth_half*2);
            gapSize = cameraWidth_half *2* gapPercentage / (size.x + 1);

            girdSize = cameraWidth_half *2* (1 - gapPercentage) / size.x;
            Debug.Log("gapsize before:" + cameraWidth_half * 2 * gapPercentage);
        }
        //widthPercentage = (1-gapPercentage)/
        Vector2 gapVec = new Vector2(gapSize, -gapSize);
        Vector2 halfGridVec = new Vector2(girdSize / 2,-girdSize / 2);
        float gScale = girdSize / spriteSize;
        Debug.Log("girdSize:" + girdSize + " spriteSize:" + spriteSize + "gscale:" + gScale);
        for (int y = 0; y < size.y; y++)
        {
            for(int x = 0; x < size.x; x++)
            {
                Vector2 pos = startPoint + new Vector2(x * (gapSize + girdSize), -y * (gapSize + girdSize))+halfGridVec+gapVec;
                
                GameObject g= createGrid(pos, gScale, y * size.x + x);
                g.name = "gird" + x + "-" + y;
            }
        }
    }
    public GameObject createGrid(Vector2 pos,float scale,int girdIdx){
        GameObject gird= Instantiate(girds[girdIdx%girds.Count], pos, Quaternion.Euler(0, 0, 0));
        gird.transform.localScale = new Vector2(scale, scale);
        return gird;
    }
	// Use this for initialization
	void Start () {
        Sprite sprite = girds[0].GetComponent<SpriteRenderer>().sprite;
        float aspect = sprite.bounds.size.x / sprite.bounds.size.y;
        scale = panelFix.getScale(aspect, sprite.bounds.size);
        init(null, new vec2i(5, 4));

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
