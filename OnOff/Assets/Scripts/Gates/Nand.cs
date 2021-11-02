using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nand : Gate, IGate
{
    private void Start()
    {
        inputs = new bool[NumberOfInputs];
        outputs = new bool[NumberOfOutputs];
        check = checkFunc;
    }

    public void checkFunc()
    {

        foreach (bool b in inputs)
        {
            if (!b)
            {
                setOutputs(true);
                return;
            }
        }
        setOutputs(false);
        return;
    }
}
