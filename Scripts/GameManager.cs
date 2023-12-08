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
    public bool isLevelSuccessful;
    public TextMeshProUGUI gameOverText;

    //End level
    public GameObject endLevelZone;
    public GameObject successText;

    //Protected Storage
    public Storage storage;

    //Level #
    public TextMeshProUGUI levelText;
    private int level;


    void Start()
    {
      isGameActive = true;
      StartCoroutine(LevelEndCountdown());
      storage = GameObject.Find("Storage").GetComponent<Storage>();  

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

    public void LevelSuccess()
    {
       if (isLevelSuccessful == true) 
        {
            endLevelZone.gameObject.SetActive(true);
            successText.gameObject.SetActive(true);
            isGameActive = false;
        }
    }

    IEnumerator LevelEndCountdown()
    {
        yield return new WaitForSeconds(30);
        isLevelSuccessful = true;
        LevelSuccess();
    }

    public void LevelNumber(int levelUp)
    {
        level += levelUp;
        levelText.text = "Level: " + level;
    }
}
