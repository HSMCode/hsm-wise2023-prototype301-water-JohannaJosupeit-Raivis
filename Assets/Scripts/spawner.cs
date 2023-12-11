using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] food;
    private float t;
    private GameObject foodObject;


    // Start is called before the first frame update
    void Start()
    {
        t = 0f;
    }

    private void Update()
    {
        t = t + Time.deltaTime;
        if (t >= 5)
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
