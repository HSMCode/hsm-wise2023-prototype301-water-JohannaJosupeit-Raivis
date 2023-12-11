using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swimmingFish : MonoBehaviour
{
    public float speed;
    public int points;
    private bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter()
    {
        
        if(isAlive)
        {
            playerMovement.exactScore += points;
            isAlive = false;
            this.gameObject.SetActive(false);
        }
        
    }
}
