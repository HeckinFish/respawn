using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMoves : MonoBehaviour
{
    //Boundary variable
    private float bound = -1;

    //Movement speed
    private float speed = 9;

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
