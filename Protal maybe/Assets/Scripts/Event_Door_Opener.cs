using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Door_Opener : BaseEvent
{
    public GameObject door;
    public Transform pivot;
    public BoxCollider2D doorSelect;
    public float speedModifier;
    bool door_activate = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (door_activate == true){
            door.transform.localScale = new Vector3(0,0,0);
        }
    }

    public override void ActivateEvent()
    {
        Debug.Log("Door Opened");

        doorSelect.enabled=false;

        door_activate = true;
    }


}


