using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage {
    public const byte KIND_PHYSICAL = 0;
    public const byte KIND_MAGICAL = 1;
    public const byte KIND_REAL = 2;
    public const string TAG_ATTACK = "attack";
    public const string TAG_FIRE = "fire";
    public const string TAG_ICE = "ice";
    public const string TAG_THUNDER = "thunder";
    public const string TAG_REMOTE = "remote";
    public const string TAG_CLOSE = "close";
    public int num;
    public byte kind;
    public unitControler creater = null;
    public bool vaild =true;
    public List<string> tag=new List<string>();
    public Damage(int num,byte kind,unitControler creater)
    {
        this.num = num;
        this.kind = kind;
        this.creater = creater;
    }
    public Damage(int num, byte kind, unitControler creater,List<string> tags)
    {
        this.num = num;
        this.kind = kind;
        this.creater = creater;
        this.tag = tags;
    }
}
