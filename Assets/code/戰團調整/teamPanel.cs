using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamPanel : MonoBehaviour {
    protected List<RoleRecord> units = null;
    public List<GameObject> prafeb;
    public List<GameObject[,]> girdGroups=new List<GameObject[,]>();
    //public GameObject[,] girds;
    public float scale;
    public float gapPercentage = 0.0f;//間隔在畫面中的百分比
    public static Vector2 ScreenLeftUp()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(0,Camera.main.pixelHeight));
    }
    public static Vector2 ScreenRightDown()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0));
    }
    public void createGroup(List<RoleRecord> units,vec2i matric,Vector2 leftUp,Vector2 rightDown){
        GameObject[,] girds = new GameObject[matric.y,matric.x];
        Vector2 startPoint;
        float width = rightDown.x - leftUp.x;
        float height =leftUp.y -rightDown.y;
        float gapSize = 0;
        float girdSize = 0;
        float fieldAspect = width / height;
        float girdAspect = (float)matric.x / (float)matric.y; //(float)(girdSize.x) / (float)girdSize.y;
        float unitPixel = prafeb[0].GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        float spriteSize = prafeb[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        //Debug.Log("field aspect:" + fieldAspect +"gird aspect:"+girdAspect);
        //Debug.Log("left up:" + leftUp + "right down:" + rightDown);
        int bigger = matric.x;
        if(matric.y > matric.x)
        {
            bigger = matric.y;
        }
        if (fieldAspect > girdAspect)
        {
            Vector2 boundWidth = new Vector2((width - height) / 2, 0);
            //Debug.Log("bound width:" + boundWidth);
            startPoint = leftUp + boundWidth;
            gapSize = (height * gapPercentage) / (bigger + 1);
            girdSize = (height * (1 - gapPercentage) / bigger);
            //Debug.Log("girdSize:"+ girdSize);
        }
        else {
            startPoint = leftUp;
            gapSize = width * gapPercentage / (bigger + 1);
            girdSize = width * (1 - gapPercentage) / bigger;
        }
        Vector2 gapVec = new Vector2(gapSize, -gapSize);
        Vector2 halfGridVec = new Vector2(girdSize / 2, -girdSize / 2);
        float gScale = girdSize / spriteSize;
        //Debug.Log("girdSize:" + girdSize + " spriteSize:" + spriteSize + "gscale:" + gScale);
        //Debug.Log("start point x:" + startPoint.x + "gap x:"+gapSize +"halfGridVec x:"+girdSize/2);
        for (int y = 0; y < matric.y; y++)
        {
            for (int x = 0; x < matric.x; x++)
            {
                Vector2 pos = startPoint + new Vector2(x * (gapSize + girdSize), -y * (gapSize + girdSize)) + halfGridVec + gapVec;

                GameObject g = createGrid(pos, gScale, new vec2i(x, y), (y * matric.x + x) %prafeb.Count);
                //girds.Add(g);
                girds[y, x] = g;
                //g.name = "gird" + x + "-" + y;
                
            }
        }
        girdGroups.Add(girds);
    }
    /*public void init(List<RoleRecord> units, vec2i size)
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
                
                GameObject g= createGrid(pos, gScale,new vec2i(x,y));
                g.name = "gird" + x + "-" + y;
            }
        }
    }
    */
    public GameObject createGrid(Vector2 pos,float scale,vec2i index,int girdNo){
        int girdIdx = index.y * index.x + index.x;
        //Debug.Log("gird x:" + index.x + " y:" + index.y + " girdIdx:" + girdIdx);
        GameObject gird= Instantiate(prafeb[girdNo], pos, Quaternion.Euler(0, 0, 0));
        gird.transform.localScale = new Vector2(scale, scale);
        gird.GetComponent<gird>().x = index.x;
        gird.GetComponent<gird>().y = index.y;
        return gird;
    }
	// Use this for initialization
	void Start () {
        Sprite sprite = prafeb[0].GetComponent<SpriteRenderer>().sprite;
        float aspect = sprite.bounds.size.x / sprite.bounds.size.y;
        scale = panelFix.getScale(aspect, sprite.bounds.size);
        //init(null, new vec2i(5, 4));
        //createGroup(null,new vec2i(5,4),new Vector2(4.37f,0.9f),new Vector2(6.78f,-2.78f));
    }
	public void deleteGirds()
    {
        foreach (GameObject[,] girds in girdGroups)
        {
            foreach (GameObject obj in girds)
            {
                Destroy(obj);
            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
