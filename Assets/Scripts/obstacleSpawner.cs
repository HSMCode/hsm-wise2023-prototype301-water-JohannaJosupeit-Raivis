using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    private float spawnChance, randomNumber;
    private GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        spawnChance = 100f;
        randomNumber = Random.Range(0f, 101f);
        if(randomNumber < spawnChance)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        enemy = obstacles[Random.Range(0, obstacles.Length)];
        GameObject gameObject1 = Instantiate(enemy, transform.position, transform.rotation);
    }
}
