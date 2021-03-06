﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inputs : MonoBehaviour
{
    public GameObject crosshair;
    private Camera cam;
    public float xInput;
    public bool jumpInput;
    public bool shoot;
    public int equipNum=1;

    public bool CoolDown;
    public bool checkSwap;
    public int storedEquip;

    public AudioClip[] gunSounds;
    public AudioSource Audio;
    private bool playingFoot;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Cursor.visible = false;
        equipNum = 0;
        storedEquip = equipNum;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if weapon swap was done for gameplay mechnaic of avoiding shooting CD
        if (equipNum != storedEquip)
        {
            checkSwap = true;
            Audio.clip = gunSounds[3];
            Audio.Play();
        }
        storedEquip = equipNum;
        //Checks for horizontal inputs
        xInput = Input.GetAxis("Horizontal");
        

        //Controls Jumping
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpInput = true;
        }
        else
        {
            jumpInput = false;
        }


        //Controls for which gun is shooting 1 and 2 is only when click 3 is hold 
        switch (equipNum)
        {
            default:
                {
                    if (Input.GetMouseButtonDown(0) && !CoolDown)
                    {
                        shoot = true;

                        Audio.clip = gunSounds[equipNum-1];
                        Audio.Play();

                    }
                    break;
                }
           
            case 3:
                {
                    if (Input.GetMouseButton(0)&& !CoolDown)
                    {
                        shoot = true;

                        //controls which audio clip for gun shot
                        Audio.clip = gunSounds[2];
                        Audio.Play();
                    }
                    break;
                }

            case 0:
                {
                    break;
                }
        }


        //Controls to switch to proper gun on numkey press
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            equipNum = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equipNum = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            equipNum = 3;
        }


        //Tracks Crosshair to mouse position
        crosshair.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
        crosshair.transform.position = new Vector3(crosshair.transform.position.x, crosshair.transform.position.y, 0);
        if(crosshair.transform.localPosition.y<-4.3f)
        {
            cam.GetComponent<Camera_Movement>().lookDown = true;
        }
        else if(crosshair.transform.localPosition.y > -1f)
        {
            cam.GetComponent<Camera_Movement>().lookDown = false;
        }

    }
    
}
