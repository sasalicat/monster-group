using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomer : MonoBehaviour {
    public static Randomer main;
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

    public virtual int getInt()
    {
        return Random.Range(0, 100);
    }
}
