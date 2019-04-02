using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headPhantom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0)){
            Destroy(gameObject);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 m_pos = Input.mousePosition;
            //m_pos.z = 0;
            m_pos = Camera.main.ScreenToWorldPoint(m_pos);
            m_pos.z = 0;
            transform.position = m_pos;
        }
	}
}
