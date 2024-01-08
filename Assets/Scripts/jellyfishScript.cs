using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script moves the jellyfish and kills the player on collision
public class jellyfishScript
    : MonoBehaviour
{
    public AudioClip slappingSound;
    public float speed;
    private bool isAlive;
    private float t; // t for time
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //when the game start the player is alive DUH
        isAlive = true;
        // and the time starts at 0
        t = 0;
        //find the orcas animator for later
        animator = GameObject.Find("Orca").GetComponent<Animator>();
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
            //in a desperate attempt to save the game performence deactivate this object.
            this.gameObject.SetActive(false);
        }
        // if the player is alive during this frame
        if (playerMovement.isAlive)
        {
            //move the object forward (on the z- axis). The distance depends on how much time passed since the last frame and its speed
            transform.position = transform.position - transform.forward * speed * 2 * Time.deltaTime;
        }

    }

    // if an object collides with this one
    private void OnTriggerEnter(Collider other)
    {
        // check if that object is the player and if the game started already
        if (isAlive && other.gameObject.CompareTag("Player") && playerMovement.isStarted)
        {
            AudioSource.PlayClipAtPoint(slappingSound, transform.position);
            // the playerMoevent Script has to know the player is no longer alive
            playerMovement.isAlive = false;
            animator.SetBool("isAlive", false);
        }
    }
}