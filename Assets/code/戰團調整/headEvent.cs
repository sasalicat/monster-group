using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headEvent : MonoBehaviour {
    public GameObject phantom;
    protected GameObject nowPhantomObj = null;
    public GameObject rolePanel;
    public RoleRecord data;
    public void onDrag()
    {
        Debug.Log("拖動中");
        if (nowPhantomObj == null)
        {
            nowPhantomObj = Instantiate(phantom);
            nowPhantomObj.GetComponent<headPhantom>().BefDelete += substitutePanel.main.onPhantomDele;
            nowPhantomObj.GetComponent<headPhantom>().init(data);
            //nowPhantomObj.AddComponent<headPhantom>();
        }
    }
    public void onClick()
    {

    }
}
