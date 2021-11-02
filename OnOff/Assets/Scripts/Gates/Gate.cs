using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int NumberOfInputs = 2;
    public int NumberOfOutputs = 1;
    public bool[] inputs;
    public bool[] outputs;

    protected delegate void Check();
    protected Check check;

    private void Update()
    {
        check();
    }
    public void setOutputs(bool setter)
    {
        for (int i = 0; i < NumberOfOutputs; i++)
        {
            outputs[i] = setter;
        }
    }
}
