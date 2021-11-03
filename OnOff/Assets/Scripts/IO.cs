using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IO : MonoBehaviour
{
    public enum typeOfIO {input, output}
    public typeOfIO iO;
    [SerializeField]
    GameObject selected;
    public bool value;
    // Update is called once per frame
    void Update()
    {
        if (selected != null)
        {
            if (iO == typeOfIO.input)
            {
                value = selected.GetComponent<IO>().value;
            }
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

    }
    /*private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(1);
        Player p;

        if (collision.gameObject.TryGetComponent<Player>(out p))
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
                    p.select = null;
                    p.holding = false;
                }

            }
        }
    }*/
    private void OnTriggerStay2D(Collider2D collision)
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
                }
                
            }            
        }
        
    }
}
