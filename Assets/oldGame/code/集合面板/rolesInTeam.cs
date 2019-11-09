using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rolesInTeam : MonoBehaviour {
    public GameObject headObj;//手動拉取
    public GameObject mainPanel;//手動拉取
    public GameObject rolePanel;//手動拉取
    List<GameObject> heads;
    bool firstFrame = true;
    void Start()
    {
        init();
        dataWarehouse.main.onArmyUpdate += onArmyUppdate;
    }
    /*void Update()
    {
        if (firstFrame) {
            init();
            firstFrame = false;
        }
    }*/
	// Use this for initialization
    void onArmyUppdate()
    {
        cancer();
        init();
    }
    void init()
    {
        heads = new List<GameObject>();
        List<RoleRecord> army= dataWarehouse.main.nowData.army;
        foreach (RoleRecord role in army)
        {
            GameObject headIcon = Instantiate(headObj, mainPanel.transform);
            headIcon.GetComponent<roleInPanel>().init(role, rolePanel);
            heads.Add(headIcon);

        }
    }
    void cancer()
    {
        foreach(GameObject obj in heads)
        {
            Destroy(obj);
        }
        heads = null;
    }
}
