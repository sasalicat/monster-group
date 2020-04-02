using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct rect{
    Vector2 upLeft;
    Vector2 buttomRight;
    public rect(Vector2 ul,Vector2 br) {
        upLeft = ul;
        buttomRight = br;
    }
    public float aspect{
        get
        {
            return (buttomRight.x - upLeft.x) / (upLeft.y - buttomRight.y);
        }
    }
    public float width
    {
        get
        {
            return buttomRight.x - upLeft.x;
        }
    }
    public float height
    {
        get
        {
            return upLeft.y - buttomRight.y;
        }
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
        rect sceneRect =new rect(new Vector2(left_x, up_y), new Vector2(right_x, down_y));
        if (tragetCamera.aspect >= sceneRect.aspect)//camera比fitScene橫向更寬
        {//維持camera height 和sceneRect height 相同
            tragetCamera.fieldOfView = Mathf.Atan(sceneRect.height/ (2 * Mathf.Abs(mainStageZ - stage.camera_normal.z))) * Mathf.Rad2Deg * 2;//fieldOfView是height的一般對於depth的tan度數的一倍
        }//具體數學關係請看https://blog.csdn.net/lezhi_/article/details/78827549
        else
        {//維持camera width 和sceneRect width 相同
            tragetCamera.fieldOfView = Mathf.Atan((sceneRect.width/ tragetCamera.aspect) / (2 * Mathf.Abs(mainStageZ - stage.camera_normal.z)))*Mathf.Rad2Deg * 2;
        }
    }
}
