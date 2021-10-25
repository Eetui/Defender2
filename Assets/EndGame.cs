using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [Header("FloatSO's")]
    [SerializeField] private FloatSO _baseHealth;
    [SerializeField] private FloatSO _roundsPlayed;
    [SerializeField] private FloatSO _playerMoney;

    [Header("Game Over")]
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private TMP_Text _highscoreText;
    [SerializeField] private TMP_Text _currentScoreText;

    private string _highscoreKey = "Highscore";

    private void Start()
    {
        _playerMoney.Reset();
    }

    private void OnEnable()
    {
        _baseHealth.OnValueChanged += CheckForGameOver;
    }


    private void OnDisable()
    {
        _baseHealth.OnValueChanged -= CheckForGameOver;
    }

    private void CheckForGameOver()
    {
        if(_baseHealth.Value <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        var currentScore = (_playerMoney.Value * 0.5f) + (_roundsPlayed.Value * 5000);
        var currentHighscore = PlayerPrefs.GetFloat(_highscoreKey, 0f);

        if (currentHighscore < currentScore)
        {
            PlayerPrefs.SetFloat(_highscoreKey, currentScore);
            currentHighscore = currentScore;
        }

        _currentScoreText.text = currentScore.ToString();
        _highscoreText.text = currentHighscore.ToString();

        _gameOverScreen.SetActive(true);
    }
}
