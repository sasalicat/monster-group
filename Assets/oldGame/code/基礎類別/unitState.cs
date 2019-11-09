using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitState  {
    private int canAttack = 1;
    public bool CanAttack
    {
        set
        {
            if(value)
                canAttack += 1;
            else
            {
                canAttack -= 1;
            }
        }
        get
        {
            return canAttack > 0;
        }

    }
    private int canSkill = 1;
    public bool CanSkill
    {
        set
        {
            if (value)
                canSkill += 1;
            else
            {
                canSkill -= 1;
            }
        }
        get
        {
            return canSkill > 0;
        }
    }
    private int immunePhysics = 0;
    public bool ImmunePhysics
    {
        set
        {
            if (value)
                immunePhysics += 1;
            else
            {
                immunePhysics -= 1;
            }
        }
        get
        {
            return immunePhysics > 0;
        }
    }
    private int immuneMagic = 0;
    public bool ImmuneMagic
    {
        set
        {
            if (value)
                immunePhysics += 1;
            else
            {
                immunePhysics -= 1;
            }
        }
        get
        {
            return immunePhysics > 0;
        }
    } 
    
}
