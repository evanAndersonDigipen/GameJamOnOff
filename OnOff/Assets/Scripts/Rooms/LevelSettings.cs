using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
