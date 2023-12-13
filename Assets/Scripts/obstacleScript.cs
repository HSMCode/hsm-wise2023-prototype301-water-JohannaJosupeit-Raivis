using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScript : MonoBehaviour
{
    private float speed;
    private bool isAlive;
    private float t;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        isAlive = true;
        t = 0;
        animator = GameObject.Find("Orca").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 50f)
        {
            this.gameObject.SetActive(false);
        }
        if (playerMovement.isAlive)
        {
            transform.position = transform.position - transform.forward * speed * 2* Time.deltaTime;
        }
     
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(isAlive && other.gameObject.CompareTag("Player"))
        {
            playerMovement.isAlive = false;
            animator.SetBool("isAlive", false);
            Debug.Log("YOURE DEAD BITCH");
        }
        
        
    }
}
