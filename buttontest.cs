using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttontest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            Debug.Log("You pressed P");
        }

        if (Input.GetButtonDown("Shoot"))
        {
            Debug.Log("You shot");
        }

        if (Input.GetButtonDown("Block"))
        {
            Debug.Log("Blocked and reported");
        }
    }
}
