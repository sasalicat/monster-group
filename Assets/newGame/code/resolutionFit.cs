using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct rect{
    Vector2 upLeft;
    Vector2 buttomRight;
    rect(Vector2 ul,Vector2 br) {
        upLeft = ul;
        buttomRight = br;
    }
}

public class resolutionFit : MonoBehaviour
{
    public closeupStage stage;//手動拉取
    public Camera tragetCamera;//手動拉取
    public float mainStageZ = 0;
    float cameraWorldWidth;
    float cameraWordHeight;
    public float left_x;
    public float up_y;
    public float right_x;
    public float down_y;
    void Start()
    {
        cameraWordHeight = Mathf.Abs(mainStageZ- stage.camera_normal.z)*Mathf.Tan(tragetCamera.fieldOfView / 2 * Mathf.Deg2Rad);
        //cameraWordHeight = tragetCamera.orthographicSize;//獲得camera在世界坐標下的長度
        cameraWorldWidth = tragetCamera.aspect * cameraWordHeight;//獲得camera在世界坐標下的寬度
        Debug.Log("camera width:" + cameraWorldWidth + " height:" + cameraWordHeight);
    }
}
