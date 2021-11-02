using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nor : Gate, IGate
{
    public void checkFunc()
    {
        foreach (bool b in inputs)
        {
            if (b)
            {
                setOutputs(false);
                return;
            }
        }
        setOutputs(true);
    }

    // Start is called before the first frame update
    private void Start()
    {
        inputs = new bool[NumberOfInputs];
        outputs = new bool[NumberOfOutputs];
        check = checkFunc;
    }

    
}
