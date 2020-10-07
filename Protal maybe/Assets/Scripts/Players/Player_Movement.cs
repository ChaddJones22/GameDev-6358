using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Player_Inputs playerInputs;
    public Rigidbody2D playerRB;
    public Transform BulletSpawn;
    public GameObject Bullet;
    public float jumpForce;
    public float[] attackCD;
    public bool canJump;
    public float shotgunForce;
    public float launchAngle;
    public bool faceRight;
    public bool shooting;
    public bool moving;
    public bool movingBackwards;
    public bool isRising;
    public int speedForward;
    public int speedBackward;
    public Vector2 spawnDireciton;
 

    private bool[] hasGun=new bool[3] { false, false, false };
    private float speedMulti;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        equipCheck();
        angleCalculation();       
        jump();
        if(playerRB.velocity.y!=0)
        {
            
            if (playerRB.velocity.y>0)
            {
              
                isRising = true;
            }
            else if(playerRB.velocity.y < 0)
            {
                isRising = false;
            }
            
        }
        
        if(canJump)
        {
            isRising = false;
        }

        if(playerInputs.shoot)
        {
            playerInputs.shoot = false;
            StartCoroutine("shootCD");
        }

        if(playerInputs.checkSwap)
        {
            playerInputs.shoot = false;
            playerInputs.CoolDown = false;
            playerInputs.checkSwap = false;
            shooting = false;
            StopCoroutine("shootCD");
        }
        
        if(launchAngle>90 || launchAngle<-90)
        {
            this.transform.transform.eulerAngles = new Vector3(0, 180, 0);
           
            faceRight = false;
        }
        else
        {

            this.transform.eulerAngles = new Vector3(0, 0, 0);
            faceRight = true;
        }
     
        if(playerInputs.xInput!=0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
    }
    
    void FixedUpdate()
    {
        move();
    }


    //funciton to control move\\
    private void move()
    {
        if(!faceRight)
        {
            if (playerInputs.xInput > 0)
            {
                movingBackwards = true;
                speedMulti =speedBackward;
            }
            else
            {
                movingBackwards = false;
                speedMulti = speedForward;
            }
            playerRB.transform.Translate(Vector3.right * -playerInputs.xInput * speedMulti * Time.deltaTime);
            
        }
        else
        {
            if (playerInputs.xInput > 0)
            {
                movingBackwards = false;
                speedMulti = speedForward;
            }
            else
            {
                movingBackwards = true;
                speedMulti = speedBackward;
            }
            playerRB.transform.Translate(Vector3.right * playerInputs.xInput * speedMulti * Time.deltaTime);

            
        }

    }

    private void jump()
    {
        //If jump key was pressed this will make the char jump
        if (playerInputs.jumpInput && canJump)
        {
            Debug.Log("Adding force");
            canJump = false;
            playerRB.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    //Checks if gun has been picked up\\
    private void equipCheck()
    {
        if(playerInputs.equipNum!=0)
        {
            if (!hasGun[playerInputs.equipNum - 1])
            {
                playerInputs.equipNum = playerInputs.storedEquip ;
            }
        } 
    }

    //Function To Register Wep Into Inv\\
    public void pickUpWep(int gunID)
    {
        hasGun[gunID] = true;
    }

    //Clear Picked Up Wep if we have multiple stage per scene\\
    public void clearWep()
    {
        for(int x=0;x<hasGun.Length;x++)
        {
            hasGun[x] = false;
        }
    }

    public bool wepInInv(int gunID)
    {
        return (hasGun[gunID]);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //checks if player has landed to jump agian
        if(collision.gameObject.tag=="Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //checks if player has landed to jump agian
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }
    public void angleCalculation()
    {
        spawnDireciton = playerInputs.crosshair.transform.position - BulletSpawn.position;
        launchAngle = Vector2.SignedAngle(Vector2.right, spawnDireciton);
    }

    public int getEquipedWeapon()
    {
        return playerInputs.equipNum;
    }



    IEnumerator shootCD()
    {
        playerInputs.CoolDown = true;
        shooting = true;
        switch (playerInputs.equipNum)
        {
            default:
                {
                    //spawn bullet facing the crosshair
                    float angle;
                    if(!faceRight)
                    {
                        angle = Mathf.Atan2(spawnDireciton.y, -spawnDireciton.x ) * Mathf.Rad2Deg;
                    }
                    else
                    {
                        angle = Mathf.Atan2(spawnDireciton.y, spawnDireciton.x) * Mathf.Rad2Deg;
                    }
                    GameObject spawned = Instantiate(Bullet, BulletSpawn.position, transform.rotation * Quaternion.Euler(0f, 0f, angle));
                    //spawned.GetComponent<Rigidbody2D>().rotation = angle;
                    break;
                }
            case 2:
                {
                    //spawn bullet facing the crosshair

                    float angle;
                    if (!faceRight)
                    {
                        angle = Mathf.Atan2(spawnDireciton.y, -spawnDireciton.x) * Mathf.Rad2Deg;
                    }
                    else
                    {
                        angle = Mathf.Atan2(spawnDireciton.y, spawnDireciton.x) * Mathf.Rad2Deg;
                    }
                    //spawn 6 bullets with randomize angle facing crosshair
                    for (int x=0;x<7;x++)
                    {
                        GameObject spawned = Instantiate(Bullet, BulletSpawn.position, transform.rotation * Quaternion.Euler(0f, 0f, angle+ Random.Range(-10f, 10f)));
                        //spawned.GetComponent<Rigidbody2D>().rotation = angle + (Random.Range(-10f, 10f));
                    }

                    //Math to find the direction of shotguns recoil
                    float launchx = Mathf.Cos(launchAngle * Mathf.PI / 180) * shotgunForce;
                    float launchy = Mathf.Sin(launchAngle * Mathf.PI / 180) * shotgunForce;
                    playerRB.AddForce(new Vector2(launchx, launchy)*-1, ForceMode2D.Impulse);
                    
                    break;
                }         
        }
        
        yield return new WaitForSeconds(attackCD[playerInputs.equipNum-1]);
        playerInputs.CoolDown = false;
        shooting = false;
        yield return 0;
    }
}
