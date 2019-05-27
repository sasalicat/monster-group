using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragBar : MonoBehaviour
{
    Vector2 LastMousePos;
    public void onDrag()
    {
        Debug.Log("draging");
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 offset = mousePos - LastMousePos;
        offset.y = 0;
        transform.position += (Vector3)offset;
        LastMousePos = mousePos;
    }
    public void begDrag()
    {
        LastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
