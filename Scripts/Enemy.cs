using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Boundary variable
    private float bound = -1;

    //Movement speed
    private float speed = 12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Move
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        //Bound
        if (transform.position.z < bound)
        {
            Destroy(gameObject);
        }
    }
}
