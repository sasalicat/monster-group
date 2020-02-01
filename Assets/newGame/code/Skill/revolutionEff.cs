using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolutionEff : decisionArea, effectionInit
{
    public GameObject satellite;
    public Vector3 point2Center;
    public Vector3 upDirect;
    public int sateNum=5;
    public float rSpeed=1;
    public float radius = 1;
    public float cbTime=0.7f;//觸發callback的時間
    protected GameObject[] nowSatellites = null;
    protected float angleInterval;
    protected float angleOffset = 0;
    protected missile.withMissile callback =null;
    protected float total_time = 0;

    protected void createSatellite()
    {
        if (sateNum > 0)
        {
            angleInterval = 2 * Mathf.PI / (float)sateNum;
            nowSatellites = new GameObject[sateNum];
            for (int i = 0; i < sateNum; i++)
            {
                nowSatellites[i] = Instantiate(satellite, transform);
                Vector3 pos = new Vector3(Mathf.Sin(angleInterval * i) * radius, Mathf.Cos(angleInterval * i) * radius, 0);
                nowSatellites[i].transform.localPosition = pos;
                Vector3 toTraget = transform.position = nowSatellites[i].transform.position;
                /* Vector3 mix = transform.up + toTraget.normalized;

                 Vector3 satel_mix = point2Center.normalized + upDirect.normalized;
                 Quaternion rotater = Quaternion.FromToRotation(satel_mix, mix);*/
                Quaternion rotater = Quaternion.FromToRotation(point2Center,toTraget);
                //nowSatellites[i].transform.up = rotater * satellite.transform.up;
                nowSatellites[i].transform.rotation = rotater;
            }
        }
    }
    /*
    public new void Start()
    {
        base.Start();
        if (sateNum > 0)
        {
            angleInterval = 2 * Mathf.PI/(float)sateNum;
            nowSatellites = new GameObject[sateNum];
            for (int i = 0; i < sateNum; i++)
            {
                nowSatellites[i] = Instantiate(satellite,transform);
                Vector3 pos = new Vector3(Mathf.Sin(angleInterval*i)*radius,Mathf.Cos(angleInterval*i)*radius,0);
                nowSatellites[i].transform.localPosition = pos;
                Vector3 toTraget = -pos;
                Quaternion rotater = Quaternion.FromToRotation(point2Center, toTraget);
                nowSatellites[i].transform.up = rotater*nowSatellites[i].transform.up;
            }
        }
    }*/
    /*
    public new void Start()
    {
        base.Start();
        createSatellite();
    }*/
    public new void Update()
    {
        base.Update();
        angleOffset += rSpeed * Time.deltaTime;
        //Debug.Log("angle:" + angleOffset+"sin:"+Mathf.Sin(angleOffset)+"cos:"+Mathf.Cos(angleOffset));
        for(int i =0; i< nowSatellites.Length; i++)
        {
            GameObject nowone = nowSatellites[i];
            Vector3 pos = new Vector3(Mathf.Sin(angleInterval * i +angleOffset)*radius, Mathf.Cos(angleInterval * i +angleOffset)*radius, 0);
            //satellite.transform.localPosition = pos;
            Vector3 toTraget = -pos;
            Quaternion rotater = Quaternion.FromToRotation(point2Center, toTraget);
            nowone.transform.localPosition = pos;
            Vector3 rotate = rotater.eulerAngles;
            nowone.transform.localEulerAngles = rotater.eulerAngles;
        }
        total_time += Time.deltaTime;
        if(total_time >= cbTime&& callback!=null)
        {
            callback(null);
        }
    }

    public void init(Dictionary<string, object> effDict, GameObject selfPrafeb)
    {
        //comboControler traget = (comboControler)effDict["traget"];
        comboControler creater = (comboControler)effDict["creater"];
        roleAnim ranim = closeupStage.main.controler2roleAnim[creater];
        transform.position = (Vector2)ranim.Center + (Vector2)selfPrafeb.transform.position;
        callback= (missile.withMissile)effDict["callback"];
        createSatellite();
    }
}
