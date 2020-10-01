using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation_Controller : MonoBehaviour
{
    public Animator anim;
    public Player_Movement player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isMoving", player.moving);
        anim.SetBool("isJumping", player.isRising);
        anim.SetBool("Grounded", player.canJump);
        anim.SetBool("movingBackwards", player.movingBackwards);
    }
}
