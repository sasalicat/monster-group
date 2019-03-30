using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInf_Profile {
    public int lv;
    public int moneyLeft;
    public List<RoleRecord_profile> roleRecords;
    public List<int> itemInBag;
    public PlayerInf_Profile()
    {

    }
    public PlayerInf_Profile(int level,int money,List<RoleRecord> roles,List<int> itemNos)
    {
        this.lv = level;
        this.moneyLeft = money;
        roleRecords = new List<RoleRecord_profile>();
        foreach(RoleRecord role in roles)
        {
            roleRecords.Add(role.getProFile());
        }
        itemInBag = itemNos;
    }
}
