using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Manager {
    void HandleOrder(Dictionary<string, object> order);
    unitControler createUnit(Dictionary<string, object> unitInf);
}
