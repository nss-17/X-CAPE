using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.5f;
    public GameObject completeLevelUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.tag == "Player")
        {
            Debug.Log("Level Complete!!!");
        }*/
        //completeLevelUI.SetActive(true);
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        completeLevelUI.SetActive(true);
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);

        if (nextSceneIndex > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneIndex);
        }
    }

    /*public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }*/
}
