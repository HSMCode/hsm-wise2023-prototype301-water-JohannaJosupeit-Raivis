using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] food;
    private float t, height;
    private GameObject foodObject;
    public float spawnTime, maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }

    private void SpawnFood()
    {
        foodObject = food[Random.Range(0, food.Length)];
        GameObject gameObject1 = Instantiate(foodObject, transform.position + new Vector3 (0f, height, 0f), transform.rotation);
    }
}
