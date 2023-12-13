using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScript : MonoBehaviour
{
    private float speed;
    private bool isAlive;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        isAlive = true;
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 50f)
        {
            this.gameObject.SetActive(false);
        }
        transform.position = transform.position - transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(isAlive && other.gameObject.CompareTag("Player"))
        {
            isAlive = false;
            Debug.Log("YOURE DEAD BITCH");  
        }
        
        
    }
}
