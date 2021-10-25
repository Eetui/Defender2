using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void RestartGame()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        Time.timeScale = 1;
    }
}
