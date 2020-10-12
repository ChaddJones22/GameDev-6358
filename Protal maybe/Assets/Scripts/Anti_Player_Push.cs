using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anti_Player_Push : MonoBehaviour
{
    public Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Player")
        {
            this.RB.bodyType = RigidbodyType2D.Static;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Switch To Dynam");
            this.RB.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
