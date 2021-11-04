using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Gate, IGate
{
    bool PlayerCheck;
    public void checkFunc()
    {
        if (Input.GetKey(KeyCode.F) && PlayerCheck)
        {
            for (int i = 0; i < outputs.Length; i++)
            {
                outputs[i] = !outputs[i];
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    { 
        outputs = new bool[NumberOfOutputs];
        check = checkFunc;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            PlayerCheck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            PlayerCheck = false;
        }
    }
}
