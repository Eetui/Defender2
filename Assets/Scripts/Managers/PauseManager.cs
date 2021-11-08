using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private InputActionsSO _input = default;
    [SerializeField] private GameObject _pausePanel;

    private void OnEnable()
    {
        _input.OnPauseEvent += TogglePause;
    }

    private void OnDisable()
    {
        _input.OnPauseEvent -= TogglePause;
    }

    private void TogglePause()
    {
        if (_pausePanel.activeInHierarchy)
        {
            Resume();
            return;
        }

        Pause();
    }

    private void Pause()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
        _input.DisableGameplayInput();
        _input.DisableShortcutInput();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
        _input.EnableGameplayInput();
        _input.EnableShortcutInput();
    }
}