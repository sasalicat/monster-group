using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectNameList : objectList {
    public List<string> roleNames;
    public GameObject[] rolePrafebs;
    void Start()
    {
        rolePrafebs = new GameObject[rolePrafebs.Length];
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
