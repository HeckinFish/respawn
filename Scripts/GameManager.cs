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
    public bool isOnTitleScreen;
    public Button startButton;
    public TextMeshProUGUI gameOverText;

    //Score
    public TextMeshProUGUI scoreText;
    private int score;

    //Title Screen
    public GameObject titleScreen;
    public GameObject titleBackground;


    void Start()
    {
          isOnTitleScreen = true;
          isGameActive = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            Debug.Log("Start button pressed");
            GameStart();
        }

        if (Input.GetButtonDown("Exit"))
        {
            Debug.Log("Exit button pressed");
            Application.Quit();
        }
    }

    public void GameStart()
    {
        isGameActive = true;
        isOnTitleScreen = false;
        titleScreen.gameObject.SetActive(false);
        titleBackground.gameObject.SetActive(false);

    }

    public void TitleScreen()
    {
        isGameActive = false;
        isOnTitleScreen = true;
        titleScreen.gameObject.SetActive(true);
        titleBackground.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
    }

    public void GameOver()
    { 
        if (!isOnTitleScreen)
        {
            gameOverText.gameObject.SetActive(true);
            isGameActive = false;
            StartCoroutine(ResetToTitle());
        }
        
    }

    IEnumerator ResetToTitle()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
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
