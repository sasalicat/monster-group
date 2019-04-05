using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headEvent : MonoBehaviour {
    public GameObject phantom;
    protected GameObject nowPhantomObj = null;
    public RoleRecord data;
    public void onDrag()
    {
        Debug.Log("拖動中");
        if (nowPhantomObj == null)
        {
            nowPhantomObj = Instantiate(phantom);
            nowPhantomObj.GetComponent<headPhantom>().BefDelete += substitutePanel.onPhantomDele;
            nowPhantomObj.GetComponent<headPhantom>().data = data;
            //nowPhantomObj.AddComponent<headPhantom>();
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
