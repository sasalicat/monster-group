using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class chain : decisionArea {
    public LineRenderer line;
    public List<Vector3> points= new List<Vector3>();
    protected new void Update()
    {
        line.SetPositions(points.ToArray());
        base.Update();
    }

}
