using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamPanel : MonoBehaviour {
    protected List<RoleRecord> units = null;
    public List<GameObject> girds;
    public float scale;
    public float gapPercentage = 0.3f;//間隔在畫面中的百分比
    public void init(List<RoleRecord> units, vec2i size)
    {
        this.units = units;
        Vector2 startPoint = Camera.main.ScreenToWorldPoint(new Vector2(0,Camera.main.pixelHeight*0.5f));
        widthPercentage = (1-gapPercentage)/
        for (int y = 0; y < size.y; y++)
        {
            for(int x = 0; x < size.x; x++)
            {
                Vector2 
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
