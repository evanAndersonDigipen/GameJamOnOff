using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//------------------------------------------------------------------------------
//
// File Name:	GateIOGen.cs
// Author(s):	Evan Anderson
// Project:	Game Jam 1
// Course:	WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------
public class GateIOGen : MonoBehaviour
{
    [SerializeField]
    GameObject inputPrefab;
    [SerializeField]
    GameObject outputPrefab;

    Gate g;
    bool ready;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Inputssetup());
        StartCoroutine(OutputSetup());

    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            IO[] iOs = transform.GetComponentsInChildren<IO>();
            for (int i = 0; i < iOs.Length; i++)
            {
                if (iOs[i].iO == IO.typeOfIO.output)
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
    IEnumerator Inputssetup()
    {
        
        g = GetComponent<Gate>();
        Rect rect = GetComponent<SpriteRenderer>().sprite.rect;
        float x_offset;
        while (g.inputs.Length == 0) yield return new WaitForEndOfFrame();
        //if (g.inputs.Length == 0)
        if (g.inputs.Length != 1)
        {
            x_offset = 1f / (g.inputs.Length - 1);
            for (int i = 0; i < g.inputs.Length; i++)
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


        
        ready = true;
    }
    IEnumerator OutputSetup()
    {
        g = GetComponent<Gate>();
        Rect rect = GetComponent<SpriteRenderer>().sprite.rect;
        float x_offset;

        while (g.outputs.Length == 0) yield return new WaitForEndOfFrame();
        
        if (g.outputs.Length != 1)
        {
            x_offset = 1f / (g.outputs.Length - 1);
            float y_offset;
            if (g.name.Contains("lever"))
            {
                y_offset = .2f;
            }
            else
            {
                y_offset = .5f;
            }
            for (int i = 0; i < g.outputs.Length; i++)
            {
                GameObject b = Instantiate(outputPrefab, transform);
                b.transform.localPosition = new Vector3(-.5f + x_offset * i,  y_offset);
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
            float y_offset;
            if (g.name.Contains("lever"))
            {
                y_offset = .2f;
            }
            else
            {
                y_offset = .5f;
            }
            x_offset = .5f;
            GameObject b = Instantiate(outputPrefab, transform);
            b.transform.localPosition = new Vector3(-.5f + x_offset, y_offset);
            b.transform.localScale *= .25f;
        }
        ready = true;
    }
}
