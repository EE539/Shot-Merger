using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public UIScript levelUp;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            levelUp.Level();
            Invoke("LoadNextScene", 2);

        }
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //Get the index of the scene
        int nextSceneIndex = currentSceneIndex + 1; //Get the index of next the scene
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)//SceneManager.sceneCountInBuildSettings -> Total number of scene
            nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
