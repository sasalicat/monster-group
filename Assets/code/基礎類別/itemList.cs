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
    public List<string> representation;
}
