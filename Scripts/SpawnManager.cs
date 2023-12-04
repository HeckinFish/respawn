using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Spawn Position (Enemy)
    private Vector3 spawnPosLeft = new Vector3(-6, -3, 15);
    private Vector3 spawnPosRight = new Vector3(6, -13, 40);

    //Spawn intervals (Powerup)
    private float pDelay = 10;
    private float pRate = 10f;

    //Spawn Range (Powerup)
    private float spawnRange = 5.5f;

    //Prefabs
    public GameObject bearLeft;
    public GameObject bearRight;
    public GameObject powerup;

    private void Start()
    {
         //Spawn intervals (Enemy)
         int eDelay = Random.Range(1, 2);
         int eRate = Random.Range(3, 7);

         InvokeRepeating("SpawnEnemy", eDelay, eRate);
         InvokeRepeating("SpawnPowerup", pDelay, pRate);
    }

    void SpawnEnemy ()
    {
        Instantiate(bearLeft, spawnPosLeft, bearLeft.transform.rotation);
        Instantiate(bearRight, spawnPosRight, bearRight.transform.rotation);
    }

    void SpawnPowerup ()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnRange, -spawnRange), 1, 15);

        Instantiate(powerup, spawnPos, powerup.transform.rotation);
    }
}
