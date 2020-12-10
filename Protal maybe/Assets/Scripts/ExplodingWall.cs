using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingWall : MonoBehaviour
{
    public int health = 3;
    public float waitTime = 0.01f;
    public Color hitColor;
    public Color returnColor;

    bool ifRed;
    public ParticleSystem part;

    // Start is called before the first frame update
    void Start()
    {
        ifRed = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //destorys door with bullet hit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GetComponent<SpriteRenderer>().color = hitColor;
            ifRed = true;
            health--;

            if(health <= 0)
            {
               part.Play(); //partial system
               Destroy(gameObject);
            }

        }
        //calls to fade back
        if (ifRed)
        {
            StartCoroutine("FadeBack");
        }
    }

    //Fades back to starting color
    IEnumerator FadeBack()
        {
            yield return new WaitForSeconds(waitTime);
            GetComponent<SpriteRenderer>().color = returnColor;
        }

}
