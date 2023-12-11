using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] food;
    private float t;
    private GameObject foodObject;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 2f;
        t = 0f;
    }

    private void Update()
    {
        t = t + Time.deltaTime;
        if (t >= spawnTime)
        {
            SpawnFood();
            t = 0f;
        }
    }

    private void SpawnFood()
    {
        foodObject = food[Random.Range(0, food.Length)];
        GameObject gameObject1 = Instantiate(foodObject, transform.position, transform.rotation);
    }
}
