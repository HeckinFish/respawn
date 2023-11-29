using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Movement variables
    public float horizontalInput;
    private float speed = 15;

    //Boundary variable
    private float xBound = 6;

    void Update()
    {
        //Movement
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right *  horizontalInput * Time.deltaTime * speed);

        //Player bounds
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
