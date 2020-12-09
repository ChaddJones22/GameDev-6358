using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Ender : MonoBehaviour
{

    public Restart_Level levelController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            //Tells LEVEL CONTROLLER TO BEGIN LEVEL TRANSITION
            levelController.StartEnd = true;
            Static_Variables.lockPlayer = true;

        }
        
    }
}
