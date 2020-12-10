using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Next_Level : MonoBehaviour
{

    int current_scene_index;

    private void Start()
    {
        current_scene_index = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Next Level is: " + SceneManager.GetSceneByBuildIndex(current_scene_index + 1).name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(current_scene_index + 1, LoadSceneMode.Additive);
        while (!async.isDone)
        {
            yield return null;
        }
        ++current_scene_index;
        Scene nextScene = SceneManager.GetSceneByBuildIndex(current_scene_index);
        Debug.Log("New Scene is " + nextScene.name);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(current_scene_index));
        Debug.Log("New Active Scene is: " + SceneManager.GetSceneByBuildIndex(current_scene_index).name);
    }
}
