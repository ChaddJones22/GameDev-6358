using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets_Movement : MonoBehaviour
{
    public Rigidbody2D bulletRB;
    public float speedMulti;
    // Start is called before the first frame update
    public bool lifeOver;
    void OnEnable()
    {
        //Start the bullet clearing on spawn
        StartCoroutine("delete");
    }

    // Update is called once per frame
    void Update()
    {
        bulletRB.transform.Translate(Vector3.right * speedMulti*Time.deltaTime);
        if(lifeOver)
        {
            GameObject.Destroy(this.gameObject);
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
