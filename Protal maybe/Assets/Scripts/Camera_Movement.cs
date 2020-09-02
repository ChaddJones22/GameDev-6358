using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    
    // Start is called before the first frame update
    public Transform target;
    public float smoothing;
    public float camerax;
    public float cameray;
    public float offset;
    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null && transform.position != target.position)
        {
            camerax = target.position.x;
            cameray = target.position.y;
            Vector3 newPosition =new Vector3(camerax, cameray + offset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothing);
        }
    }
}
