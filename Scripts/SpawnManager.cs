using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Spawn Position (Enemy)
    private Vector3 spawnPosLeft = new Vector3(-6, 5, 15);
    private Vector3 spawnPosRight = new Vector3(6, 5, 40);

    //Spawn intervals (Powerup)
    private float pDelay = 10;
    private float pRate = 10f;

    //Spawn Range (Powerup)
    private float spawnRange = 5.5f;

    //GameObject Prefabs
    public GameObject[] enemiesLeft;
    public GameObject[] enemiesRight;
    public GameObject powerup;

    //Game Manager
    private GameManager gameManager;

    private void Start()
    {
        //Find Game Manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //Spawn intervals (Enemy)
         float eDelay = Random.Range(1, 2);
         float eRate = Random.Range(3, 7);

         InvokeRepeating("SpawnEnemy", eDelay, eRate);
         InvokeRepeating("SpawnPowerup", pDelay, pRate);
    }

    void SpawnEnemy ()
    {
        //Spawn enemies if game is active
        if (gameManager.isGameActive == true && !gameManager.isOnTitleScreen) { 
            int enemyLeftIndex = Random.Range(0, enemiesLeft.Length);
            int enemyRightIndex = Random.Range(0, enemiesRight.Length);

            Instantiate(enemiesLeft[enemyLeftIndex], spawnPosLeft, enemiesLeft[enemyLeftIndex].transform.rotation);
            Instantiate(enemiesRight[enemyRightIndex], spawnPosRight, enemiesRight[enemyRightIndex].transform.rotation);
        }
    }

    void SpawnPowerup ()
    {
        //Spawn powerup if game is active
        if (gameManager.isGameActive == true && !gameManager.isOnTitleScreen)
        {
            Vector3 spawnPos = new Vector3(Random.Range(spawnRange, -spawnRange), 3, 15);

            Instantiate(powerup, spawnPos, powerup.transform.rotation);
        }
    }
}
