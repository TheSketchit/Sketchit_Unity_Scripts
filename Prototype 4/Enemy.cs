using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AudioSource enemyAudio;
    public float speed = 2f;
    private Rigidbody enemyRb;
    private GameObject player;
    public AudioClip landingSound;
    public AudioClip deathSound;
    public bool playedDeathSound = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate the direction vector to the player's position from the enemy's position
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; 
        // The above line calculates the direction vector from the enemy's position to the player's position.
        // By subtracting the enemy's position from the player's position, we get a vector pointing from the enemy to the player.
        // Normalizing the vector makes it have a magnitude (length) of 1 for easier calculations.

        //Add force to the enemy's rigidbody in the direction of the player's position
        enemyRb.AddForce(lookDirection * speed);
        /* The above line adds a force to the enemy's Rigidbody component in the direction of the player's position.
         The direction of the force is the previously calculated lookDirection vector, 
         and the magnitude of the force is determined by the speed variable.
         By applying the force, the enemy moves towards the player, following its direction. */

        //if the enemy starts to fall, play the death sound
        if (transform.position.y < -0.3 && !playedDeathSound)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 1.0f);
            playedDeathSound = true;
        }

        //If the enemy goes off the top of the screen, destroy it.
        if (transform.position.y < -15)
        {
            Destroy(gameObject);
        }


    }
    //This method plays a sound when the enemy collides with the player or the ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            enemyAudio.PlayOneShot(landingSound, 1.0f);
        }
    }



  
    
}
