using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip pistolShootSound, shotgunShootSound, machinegunShootSound;
    static AudioSource audioScr;

    // Start is called before the first frame update
    void Start()
    {
        pistolShootSound = Resources.Load<AudioClip>("pistol shot");
        shotgunShootSound = Resources.Load<AudioClip>("shotgun shot");
        machinegunShootSound = Resources.Load<AudioClip>("machine_gun shot");
        audioScr = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void playSound(int gunType)
    {
        switch (gunType)
        {
            case 1:
                audioScr.PlayOneShot(pistolShootSound);
                break;
            case 2:
                audioScr.PlayOneShot(shotgunShootSound);
                break;
            case 3:
                audioScr.PlayOneShot(machinegunShootSound);
                break;
        }
    }
}
