using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headPhantom : MonoBehaviour {
    public List<GameObject> girdsAttach;
    public delegate void withPhantom(headPhantom phantom);
    public withPhantom BefDelete;
    public RoleRecord data;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0)){
            if(BefDelete != null)
            {
                BefDelete(this);
            }
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
    void OnTriggerEnter2D(Collider2D other)
    {
        girdsAttach.Add(other.gameObject);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        girdsAttach.Remove(other.gameObject);
    }
}
