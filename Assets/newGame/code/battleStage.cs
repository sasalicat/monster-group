using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface battleStage  {
    void display_number(unitControler who, int number, int kind);
    void display_effect(GameObject effectPrefab, Dictionary<string, object> initArgs,bool hit);
    void display_anim(unitControler unit,int animCode);
    void display_skill(unitControler protagonist,Skill skill, List<unitControler> tragets,bool isTrigger);
    void display_skillEnd();
}
