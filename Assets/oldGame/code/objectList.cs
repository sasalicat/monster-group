﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectList : MonoBehaviour {
public static objectList main=null;
    void OnEnable()
    {
        if(main != null)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }
    public GameObject mainUnit;
    public GameObject hpBar;
    public List<GameObject> prafebList;
}
