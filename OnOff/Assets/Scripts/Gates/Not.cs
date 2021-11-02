using System.Collections;
using UnityEngine;


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
        check = checkFunc;
    }

 
}
