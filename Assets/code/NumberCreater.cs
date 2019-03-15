using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NumberCreater : MonoBehaviour {
    public float normal_interval;
    public List<Sprite> normalNum;
    public float red_interval;
    public List<Sprite> redNum;
    public float green_interval;
    public List<Sprite> greenNum;
    public static NumberCreater main;
    public GameObject numberObj;
    public GameObject bitObj;
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
        GameObject obj= Instantiate(numberObj, pos, numberObj.transform.rotation);
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
}
