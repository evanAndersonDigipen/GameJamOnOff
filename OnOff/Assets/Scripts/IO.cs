using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//------------------------------------------------------------------------------
//
// File Name:	IO.cs
// Author(s):	Evan Anderson
// Project:	Game Jam 1
// Course:	WANIC VGP2
//
// Copyright ? 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------
public class IO : MonoBehaviour
{
    public enum typeOfIO {input, output}
    public typeOfIO iO;
    [SerializeField]
    GameObject selected;
    [SerializeField]
    GameObject player;
    Player playerScript;
    public bool value;

    bool wiring = false;

    [SerializeField]
    AudioClip BeginWire;
    [SerializeField]
    AudioClip EndWire;

    public float lengthClamp = 0;
    // Update is called once per frame
    void Update()
    {
        if (selected != null)
        {
            if (iO == typeOfIO.input)
            {
                value = selected.GetComponent<IO>().value;
            }

            else if (selected.GetComponent<IO>().iO == typeOfIO.output) ;

            else
            {
                selected.GetComponent<IO>().value = value;
            }
            
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, selected.transform.position);

        }
        if (value)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if(selected == null)
        {
            GetComponent<LineRenderer>().SetPosition(1, transform.position);
            if(iO == typeOfIO.input)
            {
                value = false;
            }
        }
        if(player != null)
        {
            if(playerScript != null && playerScript.select == gameObject)
            {
                player.transform.position = new Vector3(player.transform.position.x,
                Mathf.Clamp(player.transform.position.y, transform.position.y - player.GetComponent<Player>().wireLength,
                transform.position.y + player.GetComponent<Player>().wireLength));
                GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
            }
            
            if (wiring)
            {
                wire();
            }
            
        }

    }
    private void Start()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, transform.position);
    }
    
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(1);
        Player p;
       
        if (collision.TryGetComponent<Player>(out p))
        {
            Debug.Log(2);
            if (!p.holding)
            {
                Debug.Log(3);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log(4);
                    p.select = gameObject;
                    p.holding = true;
                    player = collision.gameObject;
                }
            }
            else
            {
                Debug.Log(5);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log(6);
                    selected = p.select;
                    selected.GetComponent<IO>().selected = gameObject;
                    selected.GetComponent<LineRenderer>().enabled = false;
                    p.select = null;
                    p.holding = false;
                    player = null;
                }
                
            }            
        }
        
    }*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            wiring = true;
            player = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        wiring = false;
        if(player != null)
        {
            //if(player.GetComponent<Player>().holding)
        } 
    }

    void wire()
    {
        if (player == null) return;
        playerScript = player.GetComponent<Player>();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!playerScript.holding)
            {
                playerScript.select = gameObject;
                playerScript.holding = true;
                if (selected != null)
                {
                    selected.GetComponent<IO>().selected = null;
                    selected = null;

                }
                GetComponent<AudioSource>().PlayOneShot(BeginWire);
                
            }
            else
            {
                //IO possible = playerScript.select.GetComponent<IO>();
                if (!playerScript.select != gameObject && selected == null)
                {
                    selected = playerScript.select;
                    selected.GetComponent<IO>().selected = gameObject;
                }
                if(!playerScript.select == gameObject)
                {
                    
                    selected = null;
                }


                selected.GetComponent<IO>().player = null;
                playerScript.select = null;
                playerScript.holding = false;
                player = null;
                GetComponent<AudioSource>().PlayOneShot(EndWire);
            }
        }
        //player = null;
    }
}
