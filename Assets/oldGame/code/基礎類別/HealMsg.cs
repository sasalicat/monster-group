using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMsg  {

    public int num;
    public unitControler healer;
    public HealMsg(int num,unitControler healer)
    {
        this.num = num;
        this.healer = healer;
    }
}
