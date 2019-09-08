using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_critical_25p_15t : skill_criticalTemplate
{
    protected override float multiple
    {
        get
        {
            return 1.5f;
        }
    }

    protected override int percentage
    {
        get
        {
            return 25;
        }
    }
}
