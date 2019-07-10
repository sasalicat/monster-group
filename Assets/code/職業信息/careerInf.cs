using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface careerInf{
    int careerNo
    {
        get;
    }
    string name
    {
        get;
    }
    string Commentary
    {
        get;
    }
    List<int> skillPool
    {
        get;
    }
    List<int> nexrCareer
    {
        get;
    }
    int frontCareer
    {
        get;
    }
    Dictionary<byte,int> Attributes
    {
        get;
    }
    int Price
    {
        get;
    }
}
