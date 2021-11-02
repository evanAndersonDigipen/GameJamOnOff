using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xor : Gate, IGate
{
    public void checkFunc()
    {
        int TrueCheck = 0;
        foreach (bool B in inputs)
        {
            if (B == true)
            {
                ++TrueCheck;
            }
        }
        if (TrueCheck != 1)
        {
            setOutputs(false);
            return;
        }
        setOutputs(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        inputs = new bool[NumberOfInputs];
        outputs = new bool[NumberOfOutputs];
        check = checkFunc;
    }
}