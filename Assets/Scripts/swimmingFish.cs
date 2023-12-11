using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swimmingFish : MonoBehaviour
{
    public int points;
    private bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - transform.forward * background.moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter()
    {
        
        if(isAlive)
        {
            playerMovement.exactScore += points;
            isAlive = false;
        }
        
    }
}
