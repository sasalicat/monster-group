using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fromToTest : MonoBehaviour
{
    public GameObject satellite;
    void Update()
    {
        Vector3 toCenter = transform.position- satellite.transform.position;
        Vector3 up= -satellite.transform.right;
        Quaternion rotater = Quaternion.FromToRotation(up,toCenter);
        //Debug.Log(rotater.eulerAngles);
        //satellite.transform.right = rotater * satellite.transform.right;
        satellite.transform.Rotate(rotater.eulerAngles,Space.World);
    }
}
