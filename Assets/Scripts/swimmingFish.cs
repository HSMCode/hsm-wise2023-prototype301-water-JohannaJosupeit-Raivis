using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script moves fish and lets the player eat them
public class swimmingFish : MonoBehaviour
{
    public AudioClip destructionSound;
    public float speed;
    public int points;
    private bool isAlive;
    private float t; // t for time

    // Start is called before the first frame update
    void Start()
    {
        // every fish that spawns is in fact alive
        isAlive = true;
        // and the time starts at 0 seconds
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime = time in seconds that passed since the last frame
        // counting the seconds by adding the passed time to t
        t += Time.deltaTime;

        // after 50 seconds
        if (t > 50f)
        {
            //in a desperate attempt to save the games performence deactivate this object.
            this.gameObject.SetActive(false);
        }
        if (playerMovement.isAlive == true)
        {
            //move the fish forward (on the z- axis). The distance depends on how much time passed since the last frame and its speed
            transform.position = transform.position - transform.forward * speed * 2 * Time.deltaTime;
        }
    }

    // if an object collides with this one
    private void OnTriggerEnter(Collider other)
    {
        // check if:
        //      this fish is alive
        //      its colliding with the player and not for example another fish
        //      the player is alive
        //      the game has been started
        if(isAlive && other.gameObject.CompareTag("Player") && playerMovement.isAlive && playerMovement.isStarted)
        {
            // add the points of this fish to the score from the playerMovement Script
            playerMovement.exactScore += points;
            // this fish is no longer alive :(
            isAlive = false;
            AudioSource.PlayClipAtPoint(destructionSound, transform.position);
            // deactivate this fish :(
            this.gameObject.SetActive(false);
        }
        
        
    }
}
