using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public float moveSpeed;
    private float offset;
    private Vector3 startPos;


    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        offset = startPos.z - (transform.position.z);
        if (offset > 50f)
        {
            transform.position = startPos;
        }
        else if (playerMovement.isAlive)
        {
            transform.position = transform.position - transform.forward * moveSpeed *2 * Time.deltaTime;
        }
        
    }

}
