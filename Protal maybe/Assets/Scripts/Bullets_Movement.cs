using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets_Movement : MonoBehaviour
{
    public Rigidbody2D bulletRB;
    public float speedMulti;
    public GameObject impact;
    // Start is called before the first frame update
    public bool lifeOver;
    void OnEnable()
    {
        //Start the bullet clearing on spawn
        StartCoroutine("delete");
        bulletRB.AddForce(transform.right * speedMulti, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //bulletRB.transform.Translate(Vector3.right * speedMulti * Time.deltaTime);
        if (lifeOver)
        {
            GameObject.Destroy(this.gameObject);
        }
    }


    void FixedUpdate()
    {
        
    }

    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Bullet" || collision.tag=="Weapons")
        {
            return;
        }
        else
        {
            Instantiate(impact, this.transform.position, this.transform.rotation);
            StopCoroutine("delete");
            Destroy(this.gameObject);
        }
        
    }
    */
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "Weapons" || col.gameObject.tag=="Player")
        {
            return;
        }
        else
        {
            StopCoroutine("delete");
            Instantiate(impact, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    //changes bool to kill bullets after 5sec;
    IEnumerator delete()
    {
        yield return new WaitForSeconds(5f);
        lifeOver = true;
        yield return null;
    }
}
