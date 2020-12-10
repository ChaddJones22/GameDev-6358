using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Interact : MonoBehaviour
{

    public GameObject ConnectedEvent;
    public bool PlayerInteractable;
    public bool continuos;
    public bool NotNormal;

    public bool multiEvent;
    public GameObject[] ConnectedMultiEvents;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            
        if ((collision.gameObject.tag == "Bullet" || collision.gameObject.tag=="Box") && !NotNormal)
        {
            Debug.Log("Contact");
            if (multiEvent)
            {
                for (int x = 0; x < ConnectedMultiEvents.Length; x++)
                {
                    ConnectedMultiEvents[x].GetComponent<BaseEvent>().ActivateEvent();
                }
            }
            else
            {
                ConnectedEvent.GetComponent<BaseEvent>().ActivateEvent();
            }
                
        }
        else if(collision.gameObject.tag == "Box" && NotNormal)
        {
            Debug.Log("Contact");
            ConnectedEvent.GetComponent<BaseEvent>().ActivateEvent();
        }

        if(PlayerInteractable && collision.gameObject.tag=="Player")
        {
            if (multiEvent)
            {
                for (int x = 0; x < ConnectedMultiEvents.Length; x++)
                {
                    ConnectedMultiEvents[x].GetComponent<BaseEvent>().ActivateEvent();
                }
            }
            else
            {
                ConnectedEvent.GetComponent<BaseEvent>().ActivateEvent();
            }
        }
            
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (continuos)
        {
            if (multiEvent)
            {
                for (int x = 0; x < ConnectedMultiEvents.Length; x++)
                {
                    ConnectedMultiEvents[x].GetComponent<BaseEvent>().ActivateEvent();
                }
            }
            else
            {
                ConnectedEvent.GetComponent<BaseEvent>().ActivateEvent();
            }

        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (continuos)
        {
            if (multiEvent)
            {
                for (int x = 0; x < ConnectedMultiEvents.Length; x++)
                {
                    ConnectedMultiEvents[x].GetComponent<BaseEvent>().EndEvent();
                }
            }
            else
            {
                ConnectedEvent.GetComponent<BaseEvent>().EndEvent();
            }
           
        }
        
    }
}
