using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Hallway : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector3 Pos = new Vector3(this.transform.position.x, this.transform.position.y, -10);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera_Movement>().HallwayCam(Pos);
            collision.gameObject.GetComponent<Player_Movement>().clearWep();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera_Movement>().ReAttachCam();
        }
    }
}
