using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] food;
    private float t, height;
    private GameObject foodObject;
    public float spawnTime, maxHeight;
    public int min, max;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 5f;
        t = 0f;
    }

    private void Update()
    {
        t = t + Time.deltaTime;
        if (t >= spawnTime)
        {
            
            height = Random.Range(-maxHeight, maxHeight);
            SpawnFood();
            t = 0f;
            spawnTime = Random.Range(min, max);
        }
    }

    private void SpawnFood()
    {
        foodObject = food[Random.Range(0, food.Length)];
        GameObject gameObject1 = Instantiate(foodObject, transform.position + new Vector3 (0f, height, 0f), transform.rotation);
    }
}
