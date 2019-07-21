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
    List<int> skillPool//隨機獲得一個的技能
    {
        get;
    }
    List<int> giftSkills {//全部獲得
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
