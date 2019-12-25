using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class objectNameList : objectList {
    public List<string> roleNames;
    protected GameObject[] rolePrafebs;
    public GameObject sIconInBattle;
    public List<string> keyDictNames;
    public List<string> buffInfNames;
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
    public animKeyDict getKeyDict(int index)
    {//Activator.CreateInstance:使用類別名稱來創建物件,動態產生物件的方法
        return  (animKeyDict)Activator.CreateInstance(Type.GetType(keyDictNames[index]));
    }
}
