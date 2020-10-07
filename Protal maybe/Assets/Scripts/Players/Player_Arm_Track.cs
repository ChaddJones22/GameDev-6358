using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Arm_Track : MonoBehaviour
{
    public Player_Movement player;
    public Rigidbody2D armRB;
    public Animator anim;
    public GameObject[] weaponList;

    private float angle;
    private Vector2 arm;
    public int currentequip;
    // Start is called before the first frame update
    void Start()
    {
        currentequip = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentequip!=player.getEquipedWeapon() && player.wepInInv(player.getEquipedWeapon()-1))
        {
            currentequip = player.getEquipedWeapon();
            switch (currentequip)
            {
                case 1:
                    {
                        weaponList[0].SetActive(true);
                        weaponList[1].SetActive(false);
                        weaponList[2].SetActive(false);

                        Debug.Log("ACTIVATING PISTOL");
                        break;
                    }
                case 2:
                    {
                        weaponList[0].SetActive(false);
                        weaponList[1].SetActive(true);
                        weaponList[2].SetActive(false);
                        break;
                    }
                case 3:
                    {
                        weaponList[0].SetActive(false);
                        weaponList[1].SetActive(false);
                        weaponList[2].SetActive(true);
                        break;
                    }
            }
            



        }


        //ANIMATION STUFF\\
        anim.SetBool("isShooting", player.shooting);
        anim.SetInteger("Weapon", currentequip);




        //ARM TRACKING\\
        arm = player.playerInputs.crosshair.transform.position - this.transform.position;
        if (!player.faceRight)
        {
            angle = Mathf.Atan2(-arm.y, -arm.x) * Mathf.Rad2Deg;
            this.transform.eulerAngles = new Vector3(180, 0, -angle + 180);

        }
        else
        {
            angle = Mathf.Atan2(arm.y, arm.x) * Mathf.Rad2Deg;
            this.transform.eulerAngles = new Vector3(0, 0, angle);
        }



    }


    //ANIMATION CONTROLLER
    public void stopShoot()
    {
        player.shooting = false;
    }

}
