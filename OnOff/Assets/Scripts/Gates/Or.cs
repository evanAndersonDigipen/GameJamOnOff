using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//------------------------------------------------------------------------------
//
// File Name:	Or.cs
// Author(s):	Evan Anderson
// Project:	Game Jam 1
// Course:	WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------
public class Or : Gate, IGate
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
            if (b)
            {
                setOutputs(true);
                return;
            }
        }
        setOutputs(false);
    }

}
