using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NumberCreater : MonoBehaviour {
    public const int YELLOW= 0;
    public const int RED = 1;
    public const int GREEN = 2;
    public Vector2 createPosOffset=new Vector2(0,0);
    public float normal_interval;
    public List<Sprite> normalNum;
    public float red_interval;
    public List<Sprite> redNum;
    public float green_interval;
    public List<Sprite> greenNum;
    public static NumberCreater main;
    public GameObject numberObj;
    public GameObject bitObj;
    public GameObject missPrafeb;
    // Use this for initialization
    void OnEnable()
    {
        if (main != null)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }
    public GameObject CreateFloatingNumber(int num,Vector2 pos,int kind)
    {
        GameObject obj= Instantiate(numberObj, pos+ createPosOffset, numberObj.transform.rotation);
        int numNum = num;
        int counter = 0;
        while (numNum > 0)
        {
            int nowNum = numNum % 10;//取得個位數
            Sprite image=null;
            float offset = 0;
            if (kind == 0)
            {
                image = normalNum[nowNum];
                offset = normal_interval;
            }
            else if (kind == 1)
            {
                image = redNum[nowNum];
                offset = red_interval;
            }
            else if (kind == 2) {
                image = greenNum[nowNum];
                offset = green_interval;
            }
            GameObject bit = Instantiate(bitObj, obj.transform);
            bit.transform.localPosition = new Vector2(-counter*offset,0);
            bit.GetComponent<SpriteRenderer>().sprite = image;
            counter++;
            numNum = numNum / 10;
        }
        return obj;
    }
    public  GameObject CreateMissing(Vector2 pos)
    {
        Debug.Log("CreateMissing");
        GameObject miss = Instantiate(missPrafeb, pos,Quaternion.EulerAngles(0, 0, 0));
        return miss;
    }
}
