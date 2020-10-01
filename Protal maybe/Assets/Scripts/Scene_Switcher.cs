using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Switcher : MonoBehaviour
{
    public int SceneLevel;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(SceneLevel));
        //SceneManager.UnloadSceneAsync((SceneManager.GetSceneByBuildIndex(0)));
    }
}
