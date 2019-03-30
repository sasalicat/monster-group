using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleRecord  {
    public int race;
    public List<int> careers=new List<int>();
    public List<int> skillNos=new List<int>();
    public List<int> itemNos = new List<int>();
    public unitData data;
    public RoleRecord() {
        race = 0;
        data = new unitData();
    }
    public RoleRecord(RoleRecord_profile profile)
    {
        race = profile.race;
        careers = profile.careers;
        skillNos = profile.skills;
        itemNos = profile.items;
        data = new unitData(profile.unit_profile);
    }
    public RoleRecord(int kind)
    {
        race = kind;
        data = new unitData();
    }
    public RoleRecord_profile getProFile()
    {
        return new RoleRecord_profile(race,data,careers,skillNos,itemNos);
    }
}
