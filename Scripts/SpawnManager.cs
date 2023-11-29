using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Spawn intervals
    private float delay = 4;
    private float rate = 2;

    //Spawn Position
    private Vector3 spawnPos = new Vector3(-5, -2, 15);

    //Prefabs
    public GameObject enemy1;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", delay, rate);
    }

    void SpawnEnemy ()
    {
        Instantiate(enemy1, spawnPos, enemy1.transform.rotation);
    }
}
