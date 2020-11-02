using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Door_Opener : BaseEvent
{
    public GameObject door;
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
        GameObject spawned = Instantiate(door, this.transform.position, transform.rotation);

    }
}