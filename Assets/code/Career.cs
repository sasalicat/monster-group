using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Career {
    int No
    {
        get;
    }
    void addProperty(unitData data);
    void addSkill(List<int> skillNos);
    List<int> NextNo
    {
        get;
    }
}
