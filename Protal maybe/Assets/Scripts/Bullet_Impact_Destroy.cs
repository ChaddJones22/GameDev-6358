using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Impact_Destroy : MonoBehaviour
{
    public ParticleSystem impact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, impact.main.duration);
    }
}
