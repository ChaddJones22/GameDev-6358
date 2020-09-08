using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Player_Inputs playerInputs;
    public Rigidbody2D playerRB;
    public Transform BulletSpawn;
    public GameObject Bullet;
    public float speedMulti;
    public float jumpForce;
    public float[] attackCD;
    public bool canJump;
    public float shotgunForce;
    public float launchAngle;
    public bool faceRight;
    public bool shooting;
    public bool moving;
    public Vector2 spawnDireciton;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        angleCalculation();
        jump();
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


    //funciton to control move
    private void move()
    {
        if(!faceRight)
        {
            playerRB.transform.Translate(Vector3.right * -playerInputs.xInput * speedMulti * Time.deltaTime);
            
        }
        else
        {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks if player has landed to jump agian
        if(collision.gameObject.tag=="Ground")
        {
            canJump = true;
        }
    }

    public void angleCalculation()
    {
        spawnDireciton = playerInputs.crosshair.transform.position - BulletSpawn.position;
        launchAngle = Vector2.SignedAngle(Vector2.right, spawnDireciton);
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
                        angle = Mathf.Atan2(-spawnDireciton.y, -spawnDireciton.x) * Mathf.Rad2Deg;
                    }
                    else
                    {
                        angle = Mathf.Atan2(spawnDireciton.y, spawnDireciton.x) * Mathf.Rad2Deg;
                    }
                    GameObject spawned = Instantiate(Bullet, BulletSpawn.position, transform.rotation);
                    spawned.GetComponent<Rigidbody2D>().rotation = angle;
                    break;
                }
            case 2:
                {
                    //spawn bullet facing the crosshair

                    float angle;
                    if (!faceRight)
                    {
                        angle = Mathf.Atan2(-spawnDireciton.y, -spawnDireciton.x) * Mathf.Rad2Deg;
                    }
                    else
                    {
                        angle = Mathf.Atan2(spawnDireciton.y, spawnDireciton.x) * Mathf.Rad2Deg;
                    }
                    //spawn 6 bullets with randomize angle facing crosshair
                    for (int x=0;x<7;x++)
                    {
                        GameObject spawned = Instantiate(Bullet, BulletSpawn.position, transform.rotation);
                        spawned.GetComponent<Rigidbody2D>().rotation = angle + (Random.Range(-10f, 10f));
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
