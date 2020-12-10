using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Door_Opener : BaseEvent
{
    public BoxCollider2D door;
    public bool open;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void ActivateEvent()
    {
        Debug.Log("Door Opened");
        door.enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;

    }

    public override void EndEvent()
    {
        base.EndEvent();
        door.enabled = true;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}