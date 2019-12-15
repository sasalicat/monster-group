using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectNameList : objectList {
    public List<string> roleNames;
    protected GameObject[] rolePrafebs;
    public GameObject sIconInBattle;
    protected override void OnEnable()
    {
        base.OnEnable();
        rolePrafebs = new GameObject[roleNames.Count];
    }
    public GameObject getRolePrafeb(int index)
    {
        if(rolePrafebs[index] == null)
        {
            rolePrafebs[index] = (GameObject)Resources.Load(roleNames[index]);
        }
        return rolePrafebs[index];
    }
}
