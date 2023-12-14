using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script spawns fish
public class spawner : MonoBehaviour
{
    // creates an array that stores all the differnt spawning options.
    [SerializeField] private GameObject[] food;
    private float t, height;
    private GameObject foodObject;
    public float spawnTime, maxHeight;

    // Start is called before the first frame update
    void Start()
    {
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
            // randomize the spawn height of the fish
            height = Random.Range(-maxHeight, maxHeight);

            // calls the SpawnFood method (see line 40)
            SpawnFood();

            //reset the time to 0
            t = 0f;
        }
    }

    private void SpawnFood()
    {
        // randomize an object from the array
        foodObject = food[Random.Range(0, food.Length)];

        // spawn the fish at the position of the object this script is attached to plus the randomized height from before
        GameObject gameObject1 = Instantiate(foodObject, transform.position + new Vector3(0f, height, 0f), transform.rotation);
    }
}
