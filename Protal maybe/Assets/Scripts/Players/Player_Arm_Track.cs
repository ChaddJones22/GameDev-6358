using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Arm_Track : MonoBehaviour
{
    public Player_Movement player;
    public Rigidbody2D armRB;
    private float angle;
    private Vector2 arm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arm = player.playerInputs.crosshair.transform.position - this.transform.position;
        if (!player.faceRight)
        {
            angle = Mathf.Atan2(-arm.y, -arm.x) * Mathf.Rad2Deg ;
            this.transform.eulerAngles = new Vector3(180, 0, -angle+180);

        }
        else
        {
            angle = Mathf.Atan2(arm.y, arm.x) * Mathf.Rad2Deg;
            this.transform.eulerAngles = new Vector3(0, 0, angle);
        }
        
    }
}
