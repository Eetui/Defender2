using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] private InputActionsSO _input;

    public void RestartGame()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
        _input.EnableAllInputs();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        Time.timeScale = 1;
        _input.EnableAllInputs();
    }
}
