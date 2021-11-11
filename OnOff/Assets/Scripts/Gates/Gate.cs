using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//------------------------------------------------------------------------------
//
// File Name:	Gate.cs
// Author(s):	Evan Anderson
// Project:	Game Jam 1
// Course:	WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------
public class Gate : MonoBehaviour
{
    [Tooltip("How many Inputs")]
    public int NumberOfInputs = 2;
    [Tooltip("How many Outputs")]
    public int NumberOfOutputs = 1;
    public bool[] inputs;
    public bool[] outputs;

    protected delegate void Check();
    /// <summary>
    /// Logic Function that runs every frame for the gate
    /// </summary>
    protected Check check;

    private void Update()
    {
        check();
    }
    /// <summary>
    /// Sets all outputs to a passed bool
    /// </summary>
    /// <param name="setter">Bool that it is required to set to</param>
    public void setOutputs(bool setter)
    {
        for (int i = 0; i < NumberOfOutputs; i++)
        {
            outputs[i] = setter;
        }
    }
}
