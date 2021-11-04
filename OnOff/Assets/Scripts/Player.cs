using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject select;
    public bool holding;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = rb.velocity;
        if (Input.GetKey(KeyCode.W))
        {
            pos.y = speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x = -speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x = speed;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            pos.y = 0;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            pos.x = 0;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            pos.y = 0;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            pos.x = 0;
        }
        rb.velocity = pos;
    }
}
