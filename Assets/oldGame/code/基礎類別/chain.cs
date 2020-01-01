using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class chain : decisionArea {
    public LineRenderer line;
    public List<Vector3> points= new List<Vector3>();
    protected new void Update()
    {
        Vector3[] array = points.ToArray();
        line.positionCount = points.Count;
        line.SetPositions(array);
        //line.SetPositions(points.ToArray());
        base.Update();
    }

}
