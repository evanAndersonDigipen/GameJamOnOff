using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;



public class Rooms : MonoBehaviour
{
    public bool value = false;
    //[SerializeField]
    public int id;
    public Dictionary<string, bool> roomDict;
    void Start()
    {
        if (PlayerPrefs.GetString("rooms") == "")
        {
            roomDict = new Dictionary<string, bool>();
            string dict = JsonConvert.SerializeObject(roomDict);
            PlayerPrefs.SetString("rooms", dict);
        }
        else
        {
            string dict = PlayerPrefs.GetString("rooms");
            Debug.Log(dict);
            roomDict = (Dictionary<string, bool>)JsonConvert.DeserializeObject(dict);

        }
        id = SceneManager.GetActiveScene().buildIndex;
        if (!roomDict.ContainsKey(id.ToString()))
        {
            roomDict.Add(id.ToString(), value);
            string dict = JsonConvert.SerializeObject(roomDict);
            //Debug.Log(dict);
            PlayerPrefs.SetString("rooms", dict);
        }
        StartCoroutine(serialize());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    System.Collections.IEnumerator serialize()
    {
        while (true){
            if (roomDict[id.ToString()] != value && GetComponent<Door>().TypeOfDoor == Door.typeOfDoor.exit)
            {
                roomDict[id.ToString()] = value;
                string dict = JsonConvert.SerializeObject(roomDict);
                Debug.Log(dict);
                PlayerPrefs.SetString("rooms", dict);
            }
            yield return new WaitForEndOfFrame();
        }
        
    }
    
}
