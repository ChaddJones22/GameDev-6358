using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Level : MonoBehaviour
{
    Scene current_scene;
    public float threshold = -15;

    // Start is called before the first frame update
    void Start()
    {
        current_scene = SceneManager.GetActiveScene();
        Debug.Log("Active scene is " + current_scene.name);
    }

    // Update is called once per frame
    void Update()
    {
        current_scene = SceneManager.GetActiveScene();

        //restart current level if reset button pushed 'p'
        if (Input.GetKeyDown(KeyCode.P))
        {
            GetScenes();
        }

        //players falls out of map
        if (transform.position.y < threshold)
        {
            GetScenes();
        }
    }

    void GetScenes()
    {
        SceneManager.LoadScene(current_scene.name);
        SceneManager.LoadScene("EssentialCharacter", LoadSceneMode.Additive);
    }

}
