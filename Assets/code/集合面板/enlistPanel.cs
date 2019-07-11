using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enlistPanel : MonoBehaviour {
    public GameObject mercenaryObj;//手動拉取
    public GameObject rolePanel;//手動拉取
    public GameObject soldPanel;//手動拉取
    public GameObject composPanel;//手動拉取
    public GameObject soldButtom;//手動拉取
    public GameObject composButtom;//手動拉取
    List<GameObject> itemObjs;
    List<RoleRecord> roles;
    public delegate void withRoleList(List<RoleRecord> arg);
    private withRoleList callback;
    public void removeRole(RoleRecord role)
    {
        roles.Remove(role);
    }
    public void init(List<RoleRecord> roles, withRoleList update_cb)
    {
        Debug.Log("market panel init:");
        itemObjs = new List<GameObject>();
        foreach (RoleRecord role in roles)
        {
            
            GameObject obj = (GameObject)Instantiate(mercenaryObj, soldPanel.transform);
            obj.GetComponent<roleInPanel>().init(role, rolePanel);
            obj.GetComponent<roleInPanel>().onSoldOut += removeRole;
            itemObjs.Add(obj);

        }
        this.roles = roles;
        callback = update_cb;
    }
    public void quit()
    {
        foreach (GameObject obj in itemObjs)
        {
            Destroy(obj);
        }
        gameObject.SetActive(false);
        callback(roles);
    }
    public void compositeButtomClick()
    {
        soldPanel.SetActive(false);
        composPanel.SetActive(true);
        composPanel.GetComponent<compositePanel>().init();
        soldButtom.SetActive(true);
        composButtom.SetActive(false);
    }
    public void marketButtomClick()
    {
        composPanel.GetComponent<compositePanel>().cancer();
        composPanel.SetActive(false);
        soldPanel.SetActive(true);
        composButtom.SetActive(true);
        soldButtom.SetActive(false);
    }
}
