using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class vec2i
{

    public int x;
    public int y;
    public vec2i()
    {

    }
    public vec2i(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return "（" + x + "," + y + ")";
    }


}


public class RoleRecord  {

    public int index=-1;
    public int race;
    public List<int> careers=new List<int>();
    public List<int> skillNos=new List<int>();
    public List<int> itemNos = new List<int>();

    public unitData data;
    public vec2i location=null;
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
        location = profile.location;
    }
    public RoleRecord(int kind)
    {
        race = kind;
        data = new unitData();
    }
    public RoleRecord_profile getProFile()
    {
        return new RoleRecord_profile(race,data,careers,skillNos,itemNos,location);
    }
}
