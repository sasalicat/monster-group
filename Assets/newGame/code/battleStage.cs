using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface battleStage  {
    void display_damage(unitControler who, Damage damage);
    void display_number(unitControler who, int number, int kind);
    void display_effect(GameObject effectPrefab, unitControler creater, Dictionary<string, object> initArgs);
}
