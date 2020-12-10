using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui_Canvas : MonoBehaviour
{
    public Restart_Level checkEnd;
    public Image blackPanel;
    public Text[] dialouge;
    public Text PlayerName;
    public bool stageEnd;
    public Dialogue_Script_Scriptable loadDialogue;
    public Dialogue_Script_Scriptable loadEndDialogue;
    public int dialogueIndex;


    private bool fadeInAndOut = false;
    public bool endStarted;
    private bool restart;

    private string textToType;
    private string CurrentText;
    private string pName;
    private int ID;
    private bool playOnce;

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
        if(!playOnce)
        {
            dialogueIndex = loadDialogue.getLength();
            bool breakloop = false;
            for (int i = 0; i < dialogueIndex; i++)
            {

                playText(i);
                for (int t = 0; t <= textToType.Length; t++)
                {
                    if (Input.GetKey(KeyCode.End))
                    {
                        breakloop = true;
                        break;
                    }

                    if (ID == 0)
                    {
                        PlayerName.text = pName;
                    }

                    if (Input.GetKey("e"))
                    {
                        t = textToType.Length;
                        dialouge[ID].text = textToType;
                        yield return new WaitForSecondsRealtime(0.2f);
                    }
                    else
                    {
                        CurrentText = textToType.Substring(0, t);
                        dialouge[ID].text = CurrentText;
                        yield return new WaitForSecondsRealtime(0.015f);

                    }


                }


                if (breakloop)
                {
                    break;
                }

                if (!Input.GetKey("e"))
                {
                    yield return new WaitForSecondsRealtime(0.6f);
                }

                if (i != dialogueIndex - 1)
                {
                    if (ID == 4)
                    {
                        dialouge[ID].gameObject.SetActive(false);
                    }
                    else
                    {
                        dialouge[ID].transform.parent.gameObject.SetActive(false);
                    }
                }

            }

            while (!Input.GetKeyDown("e") && !breakloop)
                yield return null;

            if (ID == 4)
            {
                dialouge[ID].gameObject.SetActive(false);
            }
            else
            {
                dialouge[ID].transform.parent.gameObject.SetActive(false);
            }
            playOnce = true;
        }
        


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
        for (float x = 0; x <= 1; x = x + .1f)
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
                        if(stageEnd)
                        {
                            dialogueIndex = loadEndDialogue.getLength();
                            bool breakloop = false;
                            for (int i = 0; i < dialogueIndex; i++)
                            {

                                playEndText(i);
                                for (int t = 0; t <= textToType.Length; t++)
                                {
                                    if (Input.GetKey(KeyCode.End))
                                    {
                                        breakloop = true;
                                        break;
                                    }

                                    if (ID == 0)
                                    {
                                        PlayerName.text = pName;
                                    }

                                    if (Input.GetKey("e"))
                                    {
                                        t = textToType.Length;
                                        dialouge[ID].text = textToType;
                                        yield return new WaitForSecondsRealtime(0.2f);
                                    }
                                    else
                                    {
                                        CurrentText = textToType.Substring(0, t);
                                        dialouge[ID].text = CurrentText;
                                        yield return new WaitForSecondsRealtime(0.015f);

                                    }


                                }


                                if (breakloop)
                                {
                                    break;
                                }

                                if (!Input.GetKey("e"))
                                {
                                    yield return new WaitForSecondsRealtime(0.6f);
                                }

                                if (i != dialogueIndex - 1)
                                {
                                    if (ID == 4)
                                    {
                                        dialouge[ID].gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        dialouge[ID].transform.parent.gameObject.SetActive(false);
                                    }
                                }

                            }

                            while (!Input.GetKeyDown("e") && !breakloop)
                                yield return null;

                        }

                        checkEnd.NextScene();
                        break;
                    }
            }
        }
    }

    public void playText(int i)
    {
        ID = loadDialogue.getSpeakerID(i);
        if (ID == 0)
        {
            pName = loadDialogue.getSpeakerName(i);
        }

        textToType=loadDialogue.getSpeakerDialogue(i);
        dialouge[ID].transform.parent.gameObject.SetActive(true);
        if(ID==4)
        {
            dialouge[ID].gameObject.SetActive(true);
        }

    }

    public void playEndText(int i)
    {
        ID = loadEndDialogue.getSpeakerID(i);
        if (ID == 0)
        {
            pName = loadEndDialogue.getSpeakerName(i);
        }

        textToType = loadEndDialogue.getSpeakerDialogue(i);
        dialouge[ID].transform.parent.gameObject.SetActive(true);
        if (ID == 4)
        {
            dialouge[ID].gameObject.SetActive(true);
        }

    }

}