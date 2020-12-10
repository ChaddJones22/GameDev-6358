using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui_Canvas : MonoBehaviour
{
    public Restart_Level checkEnd;
    public Image blackPanel;
    private bool fadeInAndOut = false;
    public bool endStarted;
    private bool restart;



    void Start()
    {
        blackPanel.enabled = true;
        StartCoroutine("fadeIn");
    }

    private void Update()
    {
        if(checkEnd.StartEnd==true && !endStarted)
        {

            endStarted=true;
            StartCoroutine("fadeOut");
        }

        if(checkEnd.StartReset && !endStarted)
        {

            endStarted = true;
            restart = true;
            StartCoroutine("fadeOut");
        }
    }


    IEnumerator fadeIn()
    {
        for (float x = 1; x >= 0; x = x - .1f)
        {
            Debug.Log(x);
            var tempColor = blackPanel.color;

            tempColor.a = x;
            blackPanel.color = tempColor;

            yield return new WaitForSecondsRealtime(0.1f);
        }

        Static_Variables.lockPlayer = false;
        fadeInAndOut = false;
        blackPanel.enabled = false;
        
    }

    IEnumerator fadeOut()
    {
        blackPanel.enabled = true;
        for (float x = 1; x <= 1; x = x + .1f)
        {
            Debug.Log(x);
            var tempColor = blackPanel.color;

            tempColor.a = x;
            blackPanel.color = tempColor;

            yield return new WaitForSecondsRealtime(0.1f);
        }

        if (endStarted)
        {
            switch (restart)
            {
                case true:
                    {
                        checkEnd.ResetScene();
                        break;
                    }
                case false:
                    {
                        checkEnd.NextScene();
                        break;
                    }
            }
        }
    }
}