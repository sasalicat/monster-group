using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureList : MonoBehaviour {
    public List<string> names;
    public RoleRecord getObjectIn(int index)
    {
        name = names[index];
        return (RoleRecord)System.Activator.CreateInstance(System.Type.GetType(name));
    }
    public static creatureList main = null;
    void OnEnable()
    {
        if (main != null)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }
}
