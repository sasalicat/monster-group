using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleRecord  {
    public int unitKind;
    public List<int> careers=new List<int>();
    public List<int> skillNos=new List<int>();
    public List<int> itemNos = new List<int>();
    public unitData data;
    public RoleRecord(int kind)
    {
        unitKind = kind;
        data = new unitData();
    }
}
