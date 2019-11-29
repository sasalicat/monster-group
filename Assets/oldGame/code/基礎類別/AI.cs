using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AI  {
    void update(unitControler self,Environment env);
}
public class voidAI : AI
{
    public void update(unitControler self, Environment env)
    {
        
    }
}