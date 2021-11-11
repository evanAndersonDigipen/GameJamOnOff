using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//------------------------------------------------------------------------------
//
// File Name:	Xnor.cs
// Author(s):	Andrew Kitzan
// Project:	Game Jam 1
// Course:	WANIC VGP2
//
// Copyright � 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------
public class Xnor : Gate, IGate
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
            setOutputs(true);
            return;
        }
        setOutputs(false);
    }

    // Start is called before the first frame update
    private void Start()
    {
        inputs = new bool[NumberOfInputs];
        outputs = new bool[NumberOfOutputs];
        check = checkFunc;
    }
}
