using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Ending_FadeIn : MonoBehaviour
{
    public Image background;
    public Text credits;

    public TextMeshProUGUI title;
    public Text Team;

    public Text thx;
    bool StartCredit;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("startEnd");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startEnd()
    {
        for (float x = 0; x <= 1; x = x + .05f)
        {
            Debug.Log(x);
            var tempColor = background.color;

            tempColor.a = x;
            background.color = tempColor;

            yield return new WaitForSecondsRealtime(0.1f);

        }

        for (float x = 0; x <= 1; x = x + .05f)
        {
            Debug.Log(x);
            var tempColor = title.color;

            tempColor.a = x;
            title.color = tempColor;
            Team.color = tempColor;

            yield return new WaitForSecondsRealtime(0.1f);

        }

        yield return new WaitForSecondsRealtime(2f);

        for (float x = 1; x >= 0; x = x - .05f)
        {
            Debug.Log(x);
            var tempColor = title.color;

            tempColor.a = x;
            title.color = tempColor;
            Team.color = tempColor;

            yield return new WaitForSecondsRealtime(0.1f);

        }




        for (float x = 0; x <= 1; x = x + .05f)
        {
            Debug.Log(x);
            var tempColor = credits.color;

            tempColor.a = x;
            credits.color = tempColor;

            yield return new WaitForSecondsRealtime(0.1f);

        }

        yield return new WaitForSecondsRealtime(2f);

        for (float x = 1; x >= 0; x = x - .05f)
        {
            Debug.Log(x);
            var tempColor = credits.color;

            tempColor.a = x;
            credits.color = tempColor;

            yield return new WaitForSecondsRealtime(0.1f);

        }

        for (float x = 0; x <= 1; x = x + .05f)
        {
            Debug.Log(x);
            var tempColor = thx.color;

            tempColor.a = x;
            thx.color = tempColor;

            yield return new WaitForSecondsRealtime(0.1f);

        }

        yield return new WaitForSecondsRealtime(2f);

        for (float x = 1; x >= 0; x = x - .05f)
        {
            Debug.Log(x);
            var tempColor = thx.color;

            tempColor.a = x;
            thx.color = tempColor;

            yield return new WaitForSecondsRealtime(0.1f);

        }

        yield return new WaitForSecondsRealtime(1f);


        SceneManager.LoadScene("MainMenu");

        Destroy(GameObject.Find("MusicForWholeGame"));

    }


}
