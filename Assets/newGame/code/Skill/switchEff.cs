using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchEff : MonoBehaviour, effectionInit
{
    public void init(Dictionary<string, object> effDict, GameObject prafeb)
    {
        GameObject traget = (GameObject)effDict["traget"];
        transform.parent = traget.transform;
        transform.localPosition = prafeb.transform.position;
    }
    public virtual void off()
    {
        Destroy(gameObject);
    }
}
