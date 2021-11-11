using UnityEngine.SceneManagement;
using UnityEngine;
//------------------------------------------------------------------------------
//
// File Name:	MiscFunc.cs
// Author(s):	Evan Anderson
// Project:	Game Jam 1
// Course:	WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------
public class MiscFunc : MonoBehaviour
{
    [SerializeField]
    bool the_audio;
    // Start is called before the first frame update
    void Start()
    {
        if (the_audio)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void Manual()
    {
        string path = Application.dataPath + "/../Manual.txt";
        //GetComponentInChildren<UnityEngine.UI.Text>().text = path; 
        System.Diagnostics.Process.Start(path);
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
