using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleRecord_profile  {
    public int race;
    public unitData_Profile unit_profile;
    public List<int> careers;
    public List<int> skills;
    public List<int> items;
    public RoleRecord_profile() { 
    }
    public RoleRecord_profile(int race,unitData unit,List<int> careers,List<int> skills,List<int> items) {
        this.race = race;
        unit_profile = unit.getProflie();
        this.careers = careers;
        this.skills = skills;
        this.items = items;
    }
}
