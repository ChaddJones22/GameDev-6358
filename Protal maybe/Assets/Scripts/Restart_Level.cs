using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Level : MonoBehaviour
{
    Scene current_scene;
    public float threshold = -15;
    public GameObject EssentialEntities;
    public Transform StartLocation;

    // Start is called before the first frame update
    void Start()
    {
        current_scene = SceneManager.GetActiveScene();
        Debug.Log("Active scene is " + current_scene.name);
        EssentialEntities.gameObject.transform.position = new Vector3(StartLocation.position.x, StartLocation.position.y,0f);
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

        

    }

    void GetScenes()
    {
        SceneManager.LoadScene(current_scene.name);
    }

    public void NextScene()
    {
        int CurrentIndex = current_scene.buildIndex +1;
        
        SceneManager.LoadScene(CurrentIndex,LoadSceneMode.Single) ; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //players falls out of map
        if (collision.tag=="Player")
        {
            GetScenes();
        }
    }
}
