using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class assemblePoint : MonoBehaviour {
    public List<RoleRecord> forSold;
    public GameObject assemblePanel;
	// Use this for initialization
	void Start () {
        forSold.Add(careerList.main.randomRoleFor(3));
        forSold.Add(careerList.main.randomRoleFor(2));
        forSold.Add(careerList.main.randomRoleFor(4));
    }
    void onClick()
    {
        assemblePanel.SetActive(true);
        assemblePanel.GetComponent<enlistPanel>().init(forSold, updateList);
    }
    public void updateList(List<RoleRecord> list)
    {
        forSold = list;
    }
}
