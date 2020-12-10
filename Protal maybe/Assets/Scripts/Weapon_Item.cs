using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Item : MonoBehaviour
{
    /*
     * Gun IDS
     * Pistol=0
     * Shotgun=1
     * Assualt Rifle=2
    */
    public int gunId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player In Range");
            Debug.Log("Picked Up: " + gunId);
            collision.GetComponent<Player_Movement>().pickUpWep(gunId);
            Destroy(this.gameObject);
        }
    }
}
