﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : decisionArea {
    public GameObject traget;
    public float speed;
    public float Zrotate;
    public float minDist=0;
    public delegate void withMissile(missile arg);
    public withMissile on_missile_hited;
    public virtual Vector2 tragetPoint
    {
        get
        {
            return traget.transform.position;
        }
    }
    private void destorySelf(missile self)
    {
        Destroy(gameObject);
    }

	// Use this for initialization
	protected new void Start () {
        on_missile_hited += destorySelf;
	}
	
	// Update is called once per frame
	new void Update () {
        if (traget == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Vector2 toTraget = tragetPoint - (Vector2)transform.position;
            transform.right = toTraget;
            transform.Rotate(0, 0, Zrotate);
            if (toTraget.magnitude <= minDist)
            {
                if (on_missile_hited != null)
                {
                    on_missile_hited(this);
                }
            }
            else if (toTraget.magnitude < speed * Time.deltaTime)
            {
                transform.position = tragetPoint;
            }
            else
            {
                //transform.Translate(-Vector2.up * speed * Time.deltaTime);
                transform.position += (Vector3)(toTraget.normalized * Time.deltaTime*speed);
            }
        }
	}
}
