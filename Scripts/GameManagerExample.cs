using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerExample : MonoBehaviour
{
    public GameObject endLevelScreen;

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
            }
    }
}
