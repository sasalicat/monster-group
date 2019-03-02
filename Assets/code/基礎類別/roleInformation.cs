using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roleInformation  {
    public unitData data;
    public List<int> skillNos;
    public int raceNo;
    public roleInformation(unitData data,List<int> skillNos,int raceNo)
    {
        this.data = data;
        this.skillNos = skillNos;
        this.raceNo = raceNo;
    }
}
