using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    //Game state
    public bool isGameActive;
    public Button restartButton;
    public TextMeshProUGUI gameOverText;

    //Score
    public TextMeshProUGUI scoreText;
    private int score;


    void Start()
    {
          score = 0;
          ScoreCount(0);
          isGameActive = true;

    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ScoreCount(int scoreUp)
    {
        score += scoreUp;
        scoreText.text = "Score: " + score;
    }
}
