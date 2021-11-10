using UnityEngine.SceneManagement;
using UnityEngine;

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
        string path = Application.dataPath + "/Manual.txt";
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
