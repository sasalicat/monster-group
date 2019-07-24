using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface unitControler{
    void heal(int num, unitControler from);
    void takeDamage(Damage damage);
    void addBuff(string buffName,Dictionary<string,object> buffargs);
    void action(float time);
}
