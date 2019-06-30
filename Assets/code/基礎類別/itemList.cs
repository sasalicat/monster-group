using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemList : MonoBehaviour {
    public static itemList main = null;
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
    void Start()
    {
        objects = new List<item_representation>();
        for (int i=0;i<representation.Count;i++) {
            string name = representation[i];
            if (name !="" || name != null)
            {
                if (Type.GetType(name) == null)
                {//若無此類
                    Debug.Log("item_representation:" + name+"不存在");
                    objects.Add(null);
                }
                else
                {
                    Debug.Log("Activator.CreateInstance:" + name);
                    objects.Add((item_representation)System.Activator.CreateInstance(System.Type.GetType(name)));
                }
            }
            else
            {
                objects.Add(null);
            }
        }
    }
    public List<string> representation;
    public List<item_representation> objects;
}
