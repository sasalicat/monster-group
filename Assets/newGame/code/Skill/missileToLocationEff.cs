using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileToLocationEff :MonoBehaviour,  effectionInit
{
    protected Vector2 destination;
    public float speed;
    public float Zrotate;
    BasicDelegate.withNone on_reach_destination;

    public void init(Dictionary<string, object> effDict, GameObject prafeb)
    {
        comboControler creater = ((comboControler)effDict["creater"]);
        transform.position = (Vector2)closeupStage.main.controler2roleAnim[creater].Center + (Vector2)prafeb.transform.position;

        destination = (Vector2)effDict["destination"];

        BasicDelegate.withNone cb = (BasicDelegate.withNone)effDict["callback"];
        on_reach_destination += cb;

    }
    void Update()
    {
        float now_speed = speed * Time.deltaTime;
        Vector2 toTraget = destination - (Vector2)transform.position;
        transform.right = toTraget;
        transform.Rotate(0, 0, Zrotate);
        if (toTraget.magnitude <= now_speed)
        {
            transform.position = destination;
            if (on_reach_destination != null)
            {
                on_reach_destination();
            }
            Destroy(gameObject);
        }
        else
        {
            transform.position += (Vector3)(toTraget.normalized * now_speed);
        }
    }
}
