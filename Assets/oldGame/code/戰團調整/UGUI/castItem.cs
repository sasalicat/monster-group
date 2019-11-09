using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class castItem : MonoBehaviour {
    public GraphicRaycaster m_Raycaster;
    public GraphicRaycaster m_Raycaster2;
    public PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;
    public static castItem main;
    // Use this for initialization
    void Start () {
		if(main!= null)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
	}
	public GameObject cast()
    {
        Debug.Log("cast gameObject name:" + gameObject.name);
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray

        m_Raycaster2.Raycast(m_PointerEventData, results);
        foreach (RaycastResult result in results)//優先回傳頭像
        {
            Debug.Log("rayCast2 Hit " + result.gameObject.name);
            if (result.gameObject.tag == "itemIcon")
            {
                return result.gameObject;
            }
        }
        foreach (RaycastResult result in results)
        {//再回傳裝備欄
            if(result.gameObject.tag == "itemBar")
            {
                return result.gameObject;
            }
        }
        return null;
    }
	// Update is called once per frame
	void Update () {
        //Check if the left Mouse button is clicked
        /*
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                Debug.Log("rayCast1 Hit " + result.gameObject.name);
            }
            m_Raycaster2.Raycast(m_PointerEventData, results);
            foreach (RaycastResult result in results)
            {
                Debug.Log("rayCast2 Hit " + result.gameObject.name);
            }
        }*/
    }
}
