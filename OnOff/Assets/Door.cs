using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class Door : MonoBehaviour
{
    public enum typeOfDoor { entrance, exit };
    public typeOfDoor TypeOfDoor;
    public GameObject prefab;

    Rooms rooms;
    GameObject g;

    [SerializeField]
    Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        g = Instantiate(prefab, gameObject.transform);
        if(TypeOfDoor == typeOfDoor.exit) g.transform.localPosition = new Vector3(-.5f, -.5f); 
        else g.transform.localPosition = new Vector3(-.5f, 1);

        g.transform.localScale *= .25f;

        rooms = GetComponent<Rooms>();

        /*foreach(KeyValuePair<int, bool> keyValuePair in rooms.roomDict)
        {
            Debug.Log(keyValuePair);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (TypeOfDoor == typeOfDoor.exit)
        {
            rooms.value = g.GetComponent<IO>().value;
            if (rooms.value)
            {
                GetComponent<SpriteRenderer>().sprite = sprites[1];
                GetComponent<Collider2D>().isTrigger = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = sprites[0];
                GetComponent<Collider2D>().isTrigger = false;
            }
        }
        else
        {
            //g.transform.localPosition = new Vector3(g.transform.localPosition.x, .5f);
            g.GetComponent<IO>().value = rooms.roomDict[(rooms.id - 1).ToString()];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out _))
        {
            if(TypeOfDoor == typeOfDoor.exit)
            {
                SceneManager.LoadScene(rooms.id + 1);
            }
            else
            {
                SceneManager.LoadScene(rooms.id - 1);
            }
            
        }
    }
}
