using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage {
    public const byte KIND_PHYSICAL = 0;
    public const byte KIND_MAGICAL = 1;
    public const byte KIND_REAL = 2;
    public int num;
    public byte kind;
    public unitControler creater = null;
    public bool vaild =true;
    public Damage(int num,byte kind,unitControler creater)
    {
        this.num = num;
        this.kind = kind;
        this.creater = creater;
    }
}
