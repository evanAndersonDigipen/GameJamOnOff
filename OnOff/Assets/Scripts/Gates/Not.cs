using System.Collections;
using UnityEngine;

//------------------------------------------------------------------------------
//
// File Name:	Not.cs
// Author(s):	Evan Anderson
// Project:	Game Jam 1
// Course:	WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------
public class Not : Gate, IGate
{
    public void checkFunc()
    {
        setOutputs(!inputs[0]);
    }
    
    // Use this for initialization
    void Start()
    {
        inputs = new bool[1];
        outputs = new bool[1];
        NumberOfInputs = 1;
        NumberOfOutputs = 1;
        check = checkFunc;
    }

 
}
