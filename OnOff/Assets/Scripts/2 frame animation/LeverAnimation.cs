using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//------------------------------------------------------------------------------
//
// File Name:	LeverAnimation.cs
// Author(s):	Andrew Kitzan
// Project:	Game Jam 1
// Course:	WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------
public class LeverAnimation : MonoBehaviour
{
    public  Sprite FirstFrame;
    public Sprite SecondFrame;

    private SpriteRenderer renderer = null;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && GetComponent<Lever>().PlayerCheck)
        {
            if (renderer.sprite == FirstFrame)
            {
                renderer.sprite = SecondFrame;
            }
            else
            {
                renderer.sprite = FirstFrame;
            }
        }
    }
}
