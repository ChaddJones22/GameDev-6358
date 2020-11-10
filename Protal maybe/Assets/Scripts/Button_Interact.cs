using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Interact : MonoBehaviour
{

    public GameObject ConnectedEvent;
    public bool PlayerInteractable;
    public bool continuos;
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
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag=="Box")
        {
            Debug.Log("Contact");
            ConnectedEvent.GetComponent<BaseEvent>().ActivateEvent();
        }

        if(PlayerInteractable && collision.gameObject.tag=="Player")
        {
            ConnectedEvent.GetComponent<BaseEvent>().ActivateEvent();
        }
            
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(continuos)
        {
            ConnectedEvent.GetComponent<BaseEvent>().EndEvent();
        }
        
    }
}
