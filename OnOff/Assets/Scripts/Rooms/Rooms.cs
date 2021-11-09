﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class Rooms : MonoBehaviour
{
    public int id = 0;
    public bool value;
    private void Start()
    {
        id = SceneManager.GetActiveScene().buildIndex;
        if (!PlayerPrefs.HasKey(id.ToString()))
        {
            PlayerPrefs.SetInt(id.ToString(), System.Convert.ToInt32(value));
        }
        else
        {
            value = System.Convert.ToBoolean(PlayerPrefs.GetInt(id.ToString()));
        }
    }
    private void Update()
    {
        if (GetComponent<Door>().TypeOfDoor == Door.typeOfDoor.exit)
        {
            value = GetComponent<Door>().g.GetComponent<IO>().value;
        }
        PlayerPrefs.SetInt(id.ToString(), System.Convert.ToInt32(value));
        //Debug.Log(PlayerPrefs.GetInt(id.ToString()));
    }
}
