using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Player_Inputs playerInputs;
    public Rigidbody2D playerRB;
    public GameObject Bullet;
    public float speedMulti;
    public float jumpForce;
    public float[] attackCD;
    public bool canJump;
    public float shotgunForce;
    public float launcheAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
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
            StopCoroutine("shootCD");
        }
        
    }
    
    void FixedUpdate()
    {
        move();
    }


    //funciton to control move
    private void move()
    {
        
        playerRB.transform.Translate(Vector3.right * playerInputs.xInput * speedMulti * Time.deltaTime);

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

    IEnumerator shootCD()
    {
        playerInputs.CoolDown = true;

        switch (playerInputs.equipNum)
        {
            default:
                {
                    //spawn bullet facing the crosshair
                    Vector2 spawnDireciton = playerInputs.crosshair.transform.position - this.transform.position;
                    float angle = Mathf.Atan2(spawnDireciton.y, spawnDireciton.x) * Mathf.Rad2Deg;
                    GameObject spawned = Instantiate(Bullet, transform.position, transform.rotation);
                    spawned.GetComponent<Rigidbody2D>().rotation = angle;
                    break;
                }
            case 2:
                {
                    //spawn bullet facing the crosshair
                    Vector2 spawnDireciton = playerInputs.crosshair.transform.position - this.transform.position;
                    float angle = Mathf.Atan2(spawnDireciton.y, spawnDireciton.x) * Mathf.Rad2Deg;

                    //spawn 6 bullets with randomize angle facing crosshair
                    for (int x=0;x<7;x++)
                    {
                        GameObject spawned = Instantiate(Bullet, transform.position, transform.rotation);
                        spawned.GetComponent<Rigidbody2D>().rotation = angle + (Random.Range(-10f, 10f));
                    }


                    //Math to find the direction of shotguns recoil
                    launcheAngle = Vector2.SignedAngle(Vector2.right, spawnDireciton);
                    float launchx = Mathf.Cos(launcheAngle * Mathf.PI / 180) * shotgunForce;
                    float launchy = Mathf.Sin(launcheAngle * Mathf.PI / 180) * shotgunForce;
                    playerRB.AddForce(new Vector2(launchx, launchy)*-1, ForceMode2D.Impulse);
                    break;
                }         
        }
        yield return new WaitForSeconds(attackCD[playerInputs.equipNum-1]);
        playerInputs.CoolDown = false;
        yield return 0;
    }
}
