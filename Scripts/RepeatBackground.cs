using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    public float speed;
    private float repeatWidth;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Move BG if game is active
        if (gameManager.isGameActive == true)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        
        //Repeat BG
        if (transform.position.z < startPos.z - repeatWidth) 
        { 
             transform.position = startPos;
        }
    }
}
