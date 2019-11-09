using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class assemblePoint : MonoBehaviour {
    public List<RoleRecord> forSold;
    public GameObject assemblePanel;
	// Use this for initialization
	void Start () {
        forSold = new List<RoleRecord>();
        forSold.Add(careerList.main.randomRoleFor(3));
        forSold.Add(careerList.main.randomRoleFor(2));
        forSold.Add(careerList.main.randomRoleFor(4));
    }
    public  void onClick()
    {
        Debug.Log("在點擊時印出forSold的career信息");
        foreach(RoleRecord role in forSold)
        {
            string message = "role race:" + role.race + "career list: ";
            foreach(int c in role.careers)
            {
                message += (c + ",");
            }
            message += "skill list:";
            foreach(int s in role.skillNos)
            {
                message += (s + ",");
            }
            Debug.Log(message);
        }
        assemblePanel.SetActive(true);
        assemblePanel.GetComponent<enlistPanel>().init(forSold, updateList);
    }
    public void updateList(List<RoleRecord> list)
    {
        forSold = list;
    }
}
