using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingPlatform : MonoBehaviour
{
    public float waitTime = 0.01f;
    public Color hitColor;
    public Color returnColor;

    bool ifRed;

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