using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleRecord_v2 : RoleRecord {
    public RoleRecord_v2(int race)
    {
        this.race = race;
        data = new unitData_v2();
    }
    public RoleRecord_v2(RoleRecord_profile profile)
    {
        race = profile.race;
        careers = profile.careers;
        skillNos = profile.skills;
        itemNos = profile.items;
        data = new unitData_v2(profile.unit_profile);
        location = profile.location;
    }
}
