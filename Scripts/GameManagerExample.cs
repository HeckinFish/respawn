using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerExample : MonoBehaviour
{
    public GameObject endLevelScreen;
    public TextMeshProUGUI endLevelText;

    public bool isLevelSuccessful;

    IEnumerator LevelSuccess()
    {
        yield return new WaitForSeconds(30);
        isLevelSuccessful = true;
    }

    public void LevelEndScreen()

    {
        if (isLevelSuccessful == true)
            {
                endLevelScreen.SetActive(true);
                endLevelText.gameObject.SetActive(true);
            }
    }
}
