using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swimmingFish : MonoBehaviour
{
    public float speed;
    public int points;
    private bool isAlive;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
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
      
            transform.position = transform.position - transform.forward * speed * 2 * Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(isAlive && other.gameObject.CompareTag("Player") && playerMovement.isAlive && playerMovement.isStarted)
        {
            playerMovement.exactScore += points;
            Debug.Log("points");
            isAlive = false;
            this.gameObject.SetActive(false);
        }
        
        
    }
}
