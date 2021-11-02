using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class And : Gate, IGate
{
    private void Start()
    {
        inputs = new bool[NumberOfInputs];
        outputs = new bool[NumberOfOutputs];
        check = checkFunc;
    }

    public void checkFunc()
    {
        
        foreach(bool b in inputs)
        {
            if (!b)
            {
                setOutputs(false);
                return;
            }
        }
        setOutputs(true);
        return;
    }

}
