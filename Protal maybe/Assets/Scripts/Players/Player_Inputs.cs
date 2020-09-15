using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inputs : MonoBehaviour
{
    public GameObject crosshair;
    public Camera cam;
    public float xInput;
    public bool jumpInput;
    public bool shoot;
    public int equipNum=1;

    public bool CoolDown;
    public bool checkSwap;
    public int storedEquip;
    // Start is called before the first frame update
    void Start()
    {
        cam=GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<Camera>();
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
                    }
                    break;
                }
           
            case 3:
                {
                    if (Input.GetMouseButton(0)&& !CoolDown)
                    {
                        shoot = true;
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

    }
    
}
