using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateIOGen : MonoBehaviour
{
    [SerializeField]
    GameObject inputPrefab;
    [SerializeField]
    GameObject outputPrefab;

    Gate g;
    // Start is called before the first frame update
    void Start()
    {
        g = GetComponent<Gate>();
        Rect rect = GetComponent<SpriteRenderer>().sprite.rect;
        float x_offset;
        if (g.NumberOfInputs != 1)
        {
            x_offset = 1f / (g.NumberOfInputs - 1);
            for (int i = 0; i < g.NumberOfInputs; i++)
            {
                GameObject b = Instantiate(inputPrefab, transform);
                b.transform.localPosition = new Vector3(-.5f + x_offset * i, -.5f);
                if (x_offset != 1f)
                {
                    b.transform.localScale *= x_offset * .5f;
                }
                else
                {
                    b.transform.localScale *= .25f;
                }
            }
        }
        else
        {
            x_offset = .5f;
            GameObject b = Instantiate(inputPrefab, transform);
            b.transform.localPosition = new Vector3(-.5f + x_offset, -.5f);
            b.transform.localScale *= .25f;
        }
       
        
        if (g.NumberOfOutputs != 1)
        {
            x_offset = 1f / (g.NumberOfOutputs - 1);
            for (int i = 0; i < g.NumberOfOutputs; i++)
            {
                GameObject b = Instantiate(outputPrefab, transform);
                b.transform.localPosition = new Vector3(-.5f + x_offset * i, .5f);
                if (x_offset != 1f)
                {
                    b.transform.localScale *= x_offset * .5f;
                }
                else
                {
                    b.transform.localScale *= .25f;
                }
            }
        }
        else
        {
            x_offset = .5f;
            GameObject b = Instantiate(outputPrefab, transform);
            b.transform.localPosition = new Vector3(-.5f + x_offset, .5f);
            b.transform.localScale *= .25f;
        }
        
        

    }

    // Update is called once per frame
    void Update()
    {
        IO[] iOs = transform.GetComponentsInChildren<IO>();
        for (int i = 0; i < iOs.Length; i++)
        {
            if(iOs[i].iO == IO.typeOfIO.output)
            {
                iOs[i].value = g.outputs[0];
            }
            else
            {
                g.inputs[i] = iOs[i].value;
            }
        }
           
    }
}
