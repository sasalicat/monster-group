using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeBox : MonoBehaviour {
    public upgradePanel master;
    public void onPick(RoleRecord role) {
        master.prepareRole(role);
    }
}
