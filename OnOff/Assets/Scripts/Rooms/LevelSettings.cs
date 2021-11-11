using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//------------------------------------------------------------------------------
//
// File Name:	LevelSettings.cs
// Author(s):	Evan Anderson
// Project:	Game Jam 1
// Course:	WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------
public class LevelSettings : MonoBehaviour
{

    [SerializeField]
    GameObject player;

    [SerializeField]
    float wireLength;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Player>().wireLength = wireLength;  
    }

}
