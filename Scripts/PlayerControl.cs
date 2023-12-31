using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Movement variables
    public float horizontalInput;
    private float speed = 15;

    //Boundary variable
    private float xBound = 6;

    //Powerup prefabs
    public bool hasPowerup = false;
    public int powerupTimer;

    //Powerup indicator
    public GameObject powerupIndicator;

    //Game Manager
    private GameManager gameManager;


    //Audio
    public AudioClip impactSound;
    public AudioClip powerupSound;
    private AudioSource playerAudio;

    void Start()
    {
        //Find Game Manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //Find Audio source
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {

        //Powerup position
        powerupIndicator.transform.position = transform.position + new Vector3 (0, -0.5f, 0);

        //Movement
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

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

    //Get the powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            Debug.Log("Powerup");
            StartCoroutine(PowerupCountdown());
            powerupIndicator.gameObject.SetActive(true);
            gameManager.ScoreCount(1);
            playerAudio.PlayOneShot(powerupSound, 1.0f);
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(powerupTimer);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerAudio.PlayOneShot(impactSound, 1.0f);

            if (hasPowerup == true)
            {
                Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
                Destroy(collision.gameObject);
            }

            else if (hasPowerup == false)
            {
                Destroy(gameObject);
                Debug.Log("Collided with enemy");
                gameManager.GameOver();
            }

        }

    }

}
