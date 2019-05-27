using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillBar : MonoBehaviour
{
    public RoleRecord role;
    public void init(RoleRecord data)
    {
        role = data;
        foreach (int no in role.skillNos)
        {
            記得做createheadIcon
        }
    }
}
