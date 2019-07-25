using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 class simple
{
    string name;
    public simple(string s)
    {
        name = s;
    }
    public override string ToString()
    {
        return "simple name:"+name+",";
    }
}
public class test : MonoBehaviour {
    RoleRecord data;
    List<RoleRecord> list = new List<RoleRecord>() { new RoleRecord() };
    void setData(RoleRecord d) {
        data = d;
    }
    void OnEnable() {
        Debug.Log("onenable 被呼叫");
        list[0].race = 5;
        foreach(RoleRecord r in list)
        {
            setData(r);
            //list.Remove(r);
        }
    }
    void halfInt(int num)
    {
        num = (int)(num * 0.5);
    }
    void halfHealMsg(HealMsg msg)
    {
        msg.num = (int)(msg.num * 0.5f);
    }
	// Use this for initialization
	void Start () {
        Debug.Log("start 被呼叫");
        Debug.Log("list 長度:" + list.Count);
        bool result=list.Remove(data);
        Debug.Log("Remove 後list的長度為:" + list.Count+" result:"+result);
        int ori = 100;
        halfInt(ori);
        Debug.Log("num after half:" + ori);
        HealMsg msg = new HealMsg(100, null);
        halfHealMsg(msg);
        Debug.Log("HealMsg:"+msg.num);
    }

}
