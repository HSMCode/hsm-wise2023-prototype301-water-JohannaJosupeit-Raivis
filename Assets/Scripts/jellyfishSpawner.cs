using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// this script spawns jellyfish

public class jellySpawner : MonoBehaviour
{
    // creates an array that stores all the differnt spawning options.
    // in this case theres only 1: the jellyfish prefab
    [SerializeField] private GameObject[] food;

    private float t, height;
    private GameObject foodObject;
    public float spawnTime, maxHeight;
    public int min, max;

    // Start is called before the first frame update
    void Start()
    {
        // the first jellyfish should spawn after 5 seconds
        spawnTime = 5f;
        // time starts at 0
        t = 0f;
    }

    private void Update()
    {
        // Time.deltaTime = time in seconds that passed since the last frame
        // counting the seconds by adding the passed time to t
        t = t + Time.deltaTime;

        // if enough seconds passed and the player started the game
        if (t >= spawnTime && playerMovement.isStarted)
        {
            // randomize the spawn height of the jellyfish
            height = Random.Range(-maxHeight, maxHeight);

            // calls the SpawnFood method (see line 49)
            SpawnFood();

            //reset the time to 0
            t = 0f;

            // randomize after how many seconds the next jellyfish spawns
            spawnTime = Random.Range(min, max);
        }
    }

    // this method spawns a jellyfish and is called in line 38
    private void SpawnFood()
    {
        // randomize an object from the array (again: theres only one option in this case)
        foodObject = food[Random.Range(0, food.Length)];

        // spawn the jellyfish at the position of the object this script is attached to plus the randomized height from before
        GameObject gameObject1 = Instantiate(foodObject, transform.position + new Vector3 (0f, height, 0f), transform.rotation);
    }
}
