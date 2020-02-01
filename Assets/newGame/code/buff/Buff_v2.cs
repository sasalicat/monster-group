using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff_v2 : Buff {
    public bool deleteByDispel = false;//如果是主動驅散的這裡設置為true
    public string[] prafebNames;
    public void dispelSelf() {//主動驅散
        deleteByDispel = true;
        deleteSelf();
    }
}
